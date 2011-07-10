﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf.Builder.Jdf;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Helpers;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Extensions meant to operate on JDF elements
    /// </summary>
    public static class JdfElementExtensions {
        /// <summary>
        /// Add an intent JDF to the current JDF or document
        /// </summary>
        /// <param name="parent"></param>
        /// <returns>The newly created JDF node.</returns>
        public static XElement AddIntentElement(this XContainer parent) {
            ParameterCheck.ParameterRequired(parent, "parent");

            return parent.AddJdfElement("Product");
        }

        /// <summary>
        /// Add a process JDF to the current JDF or document
        /// </summary>
        /// <returns>The newly created JDF node.</returns>
        /// <remarks>If no types are passed, a process group node is created.</remarks>
        public static XElement AddProcessJdfElement(this XContainer parent, params string[] types) {
            ParameterCheck.ParameterRequired(parent, "parent");

            return parent.AddJdfElement(types);
        }

        /// <summary>
        /// Gets the mime type associated with the given node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string MimeType(this XElement node) {
            ParameterCheck.ParameterRequired(node, "node");

            if (node.Name == Element.JDF)
                return MimeTypeHelper.JdfMimeType;
            if (node.Name == Element.JMF)
                return MimeTypeHelper.JmfMimeType;
            return "text/xml";
        }

        /// <summary>
        /// Add a process group JDF to the current JDF or document
        /// </summary>
        /// <returns>The newly created JDF node.</returns>
        public static XElement AddProcessGroupElement(this XContainer parent) {
            ParameterCheck.ParameterRequired(parent, "parent");

            return parent.AddJdfElement("ProcessGroup");
        }

        /// <summary>
        /// Add a JDF node to the current JDF or document
        /// </summary>
        /// <returns>The newly created JDF node.</returns>
        public static XElement AddJdfElement(this XContainer parent, params string[] types) {
            ParameterCheck.ParameterRequired(parent, "parent");

            if (parent is XElement) {
                parent = (parent as XElement).NearestJdf();
            }

            var jdfNode = new XElement(Element.JDF);
            parent.Add(jdfNode);
            jdfNode.MakeJdfElementAProcess(types);

            if (jdfNode.IsJdfRoot()) {
                if (Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.GenerateJobId) {
                    jdfNode.SetJobId();
                }
                jdfNode.SetAttributeValue(XNamespace.Xmlns.GetName("xsi"), Globals.XsiNamespace.NamespaceName);
                jdfNode.SetVersion();
            }
            else {
                if (Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.GenerateJobPartId) {
                    jdfNode.SetJobPartId();
                }
            }

            if (jdfNode.IsJdfRoot() && Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.CreateAuditOnNewRootJdf) {
                jdfNode.AddAudit(Audit.Created);
            }

            return jdfNode;
        }

        /// <summary>
        /// Add an audit to the JDF's audit pool.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Configured values for author, agent name and 
        /// agent version are used if they are not passed.</remarks>
        public static XElement AddAudit(this XElement jdfNode, XName auditName, string author = null, DateTime? eventDateTime = null, string agentName = null, string agentVersion = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ParameterCheck.ParameterRequired(auditName, "auditName");
            jdfNode.ThrowExceptionIfNotJdfElement();

            if (agentName == null) {
                agentName = Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentName;
            }
            if (agentVersion == null) {
                agentVersion = Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.AgentVersion;
            }
            if (author == null) {
                author = Configuration.FluentJdfLibrary.Settings.JdfAuthoringSettings.Author;
            }
            if (eventDateTime == null) {
                eventDateTime = DateTime.UtcNow;
            }

            var auditPool = jdfNode.AuditPoolElement();
            auditPool.Add(new XElement(auditName,
                new XAttribute("AgentName", agentName),
                new XAttribute("AgentVersion", agentVersion),
                new XAttribute("Author", author),
                new XAttribute("TimeStamp", eventDateTime.Value.ToString("O"))));

            return jdfNode;
        }

        /// <summary>
        /// Modify an existing JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static JdfNodeBuilder ModifyJdfNode(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            return new JdfNodeBuilder(jdfNode);
        }

        /// <summary>
        /// Returns true if the JDF node is the root node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static bool IsJdfRoot(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();
            return (jdfNode.Document == null || jdfNode.Document.Root == jdfNode);
        }

        /// <summary>
        /// Gets the resource pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="additionalAction">Additional action to be performed on the resource pool.</param>
        /// <returns></returns>
        /// <remarks>Creates the resource pool if it does not exist.</remarks>
        public static XElement ResourcePoolElement(this XElement jdfNode, Action<XElement> additionalAction = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            jdfNode.ThrowExceptionIfNotJdfElement();

            var resourcePool = jdfNode.Element(Element.ResourcePool);
            if (resourcePool == null) {
                resourcePool = new XElement(Element.ResourcePool);
                jdfNode.Add(resourcePool);
            }

            if (additionalAction != null) {
                additionalAction(resourcePool);
            }

            return resourcePool;
        }

        /// <summary>
        /// Gets the audit pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        /// <remarks>Creates the resource link pool if it does not exist.</remarks>
        public static XElement AuditPoolElement(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            var auditPoolElement = jdfNode.Element(Element.AuditPool);
            if (auditPoolElement == null) {
                auditPoolElement = new XElement(Element.AuditPool);
                jdfNode.Add(auditPoolElement);
            }

            return auditPoolElement;
        }

        /// <summary>
        /// Gets the resource link pool of the jdf node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        /// <remarks>Creates the resource link pool if it does not exist.</remarks>
        public static XElement ResourceLinkPoolElement(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            jdfNode.ThrowExceptionIfNotJdfElement();

            var resourceLinkPool = jdfNode.Element(Element.ResourceLinkPool);
            if (resourceLinkPool == null) {
                resourceLinkPool = new XElement(Element.ResourceLinkPool);
                jdfNode.Add(resourceLinkPool);
            }

            return resourceLinkPool;
        }

        /// <summary>
        /// Link an existing resource with the given id as an output.  Promote the resource if required.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="id"></param>
        /// <exception cref="JdfException">If a resource with the given id cannot be found
        /// and promoted without breaking any existing references.</exception>
        /// <returns></returns>
        public static XElement AddOutput(this XElement jdfNode, string id) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");

            return jdfNode.LinkResource(ResourceUsage.Input, null, id);
        }

        /// <summary>
        /// Link a resource with the given name and id as an output.  If the id is null or
        /// not provided, generate a unique id.  If
        /// the resource does not exist in the current jdf or its ancestors, 
        /// check descendants.  If it is found in the descendants, promote it.  If not in the 
        /// ancestors or descendants, create it.
        /// </summary>
        /// <remarks>If you do not pass an id (or you pass a null id), a new resource will
        /// always be created.</remarks>
        /// <returns></returns>
        public static XElement AddOutput(this XElement jdfNode, XName resourceName, string id = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            return jdfNode.LinkResource(ResourceUsage.Output, resourceName, id);
        }

        /// <summary>
        /// Link an existing resource with the given id as an input.  Promote the resource if required.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="id"></param>
        /// <exception cref="JdfException">If a resource with the given id cannot be found
        /// and promoted without breaking any existing references.</exception>
        /// <returns></returns>
        public static XElement AddInput(this XElement jdfNode, string id) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ParameterCheck.StringRequiredAndNotWhitespace(id, "id");

            return jdfNode.LinkResource(ResourceUsage.Input, null, id);
        }

        /// <summary>
        /// Link a resource with the given name and id as an input.  If the id is null or
        /// not provided, generate a unique id.  If
        /// the resource does not exist in the current jdf or its ancestors, 
        /// check descendants.  If it is found in the descendants, promote it.  If not in the 
        /// ancestors or descendants, create it.
        /// </summary>
        /// <remarks>If you do not pass an id (or you pass a null id), a new resource will
        /// always be created.</remarks>
        public static XElement AddInput(this XElement jdfNode, XName resourceName, string id = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            return jdfNode.LinkResource(ResourceUsage.Input, resourceName, id);
        }

        /// <summary>
        /// Link a resource with the given name and id with the given usage.  If the id is null or
        /// not provided, generate a unique id.  If
        /// the resource does not exist in the current jdf or its ancestors, 
        /// check descendants.  If it is found in the descendants, promote it.  If not in the 
        /// ancestors or descendants, create it.
        /// </summary>
        /// <remarks>If you do not pass an id (or you pass a null id), a new resource will
        /// always be created.</remarks>
        /// <returns>The newly linked resource.</returns>
        public static XElement LinkResource(this XElement jdfNode, ResourceUsage usage, XName resourceName = null, string id = null) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            var nearestJdf = jdfNode.NearestJdf();

            if (resourceName == null && id == null) {
                throw new ArgumentException(Messages.JdfElementExtensions_LinkResource_ResourceNameOrIdOrBothRequired);
            }

            var resourcePool = nearestJdf.ResourcePoolElement();
            var resourceLinkPool = nearestJdf.ResourceLinkPoolElement();

            bool resourceJustCreated = false;
            XElement resource = null;
            if (id == null) {
                id = Globals.CreateUniqueId();
            }
            else {
                resource = jdfNode.GetResourceOrNull(id);
                if (resource == null) {
                    if (resourceName != null) {
                        resource = CreateResource(resourceName, id, resourcePool);
                        resourceJustCreated = true;
                    }
                    else {
                        throw new JdfException(
                            string.Format(Messages.JdfElementExtensions_LinkResource_CouldNotFindResourceWithGivenIdAndNameWasNotProvided, id));
                    }
                }
            }

            if (resource == null) {
                resourceJustCreated = true;
                resource = CreateResource(resourceName, id, resourcePool);
            }

            resourceLinkPool.Add(
                new XElement(resource.Name.LinkName(),
                    new XAttribute("rRef", id),
                    new XAttribute("Usage", usage)));

            //sorry about the flag, but the new resource link must exist before we look at resource promotion.
            if (!resourceJustCreated) {
                PromoteResourceIfNeeded(resource);
            }

            return resource;
        }

        static void PromoteResourceIfNeeded(XElement resource) {
            List<XElement> referencesClosestToRoot = new List<XElement>();
            int depthOfReferenceClosestToRoot = GetDepthOfReferenceClosestToRoot(resource, referencesClosestToRoot);

            var resourceDepth = resource.Depth();
            if (resourceDepth == depthOfReferenceClosestToRoot) {
                if (ThereAreLinksInSiblings(resource, referencesClosestToRoot)) {
                    resource.Remove();
                    MoveResourceToCommonParent(resource, referencesClosestToRoot[0]);
                }
            }
            else if (resource.Depth() > depthOfReferenceClosestToRoot) {
                resource.Remove();
                MoveResourceToLocationOfEarliestLink(resource, referencesClosestToRoot[0]);

            }
        }

        static bool ThereAreLinksInSiblings(XElement resource, List<XElement> referencesClosestToRoot) {
            bool linksInSiblings = false;
            foreach (var reference in referencesClosestToRoot) {
                if (reference.IsInSiblingJdf(resource)) {
                    linksInSiblings = true;
                    break;
                }
            }
            return linksInSiblings;
        }

        static int GetDepthOfReferenceClosestToRoot(XElement resource, List<XElement> referencesClosestToRoot) {
            int depthOfReferenceClosestToRoot = int.MaxValue;
            foreach (var reference in resource.ReferencingElements()) {
                var depth = reference.Depth();
                if (depth <= depthOfReferenceClosestToRoot) {
                    if (depth < depthOfReferenceClosestToRoot) {
                        referencesClosestToRoot.Clear();
                        depthOfReferenceClosestToRoot = depth;
                    }
                    referencesClosestToRoot.Add(reference);
                }
            }
            return depthOfReferenceClosestToRoot;
        }

        static void MoveResourceToLocationOfEarliestLink(XElement resource, XElement referenceClosestToRoot) {
            referenceClosestToRoot.JdfParent().ResourcePoolElement().Add(resource);
        }

        static void MoveResourceToCommonParent(XElement resource, XElement referenceClosestToRoot) {
            referenceClosestToRoot.JdfParent().JdfParent().ResourcePoolElement().Add(resource);
        }

        static XElement CreateResource(XName resourceName, string id, XElement resourcePool) {
            XElement resource;
            resource = new XElement(resourceName,
                                    new XAttribute("ID", id));
            resourcePool.Add(resource);
            return resource;
        }

        /// <summary>
        /// Gets true if the element is a JDF node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfElement(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.Name == Element.JDF;
        }

        /// <summary>
        /// Gets true if the target JDF element and the given JDF element have a common parent.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="possibleSiblingJdf"></param>
        /// <returns></returns>
        public static bool IsSiblingOf(this XElement jdfNode, XElement possibleSiblingJdf) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ParameterCheck.ParameterRequired(possibleSiblingJdf, "possibleSiblingJdf");
            jdfNode.ThrowExceptionIfNotJdfElement();
            possibleSiblingJdf.ThrowExceptionIfNotJdfElement();

            return jdfNode.HasJdfParent() && possibleSiblingJdf.HasJdfParent() && jdfNode.JdfParent() == possibleSiblingJdf.JdfParent();
        }

        /// <summary>
        /// Returns true if the node is a JDF intent node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfIntentElement(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.IsJdfElement() && element.GetJdfType() == "Product";
        }

        /// <summary>
        /// Returns true if the node is a JDF process group node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfProcessGroupElement(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.IsJdfElement() && element.GetJdfType() == "ProcessGroup";
        }

        /// <summary>
        /// Returns true if the node is a JDF process node 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsJdfProcessElement(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.IsJdfElement() && !element.IsJdfIntentElement() && !element.IsJdfProcessGroupElement();
        }

        //TODO Does the method GetJdfNodesContainingProcessType throw off the intellisense for the builders and should it just be a static method?

        /// <summary>
        /// Get any JDF Node that contains the processType passed in.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="processType"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> GetJdfNodesContainingProcessType(this XContainer element, string processType) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(processType, "processType");

            return element.JdfXPathSelectElements("//JDF").Where(item => GetJdfTypes(item).Any(t => t == processType));
        }

        /// <summary>
        /// Gets the type of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XName GetJdfType(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeValueOrNull("Type");
        }

        /// <summary>
        /// Sets the type of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XElement SetJdfType(this XElement element, string value)
        {
            ParameterCheck.ParameterRequired(element, "element");

            element.SetAttributeValue("Type", value);
            return element;
        }

        /// <summary>
        /// Gets true if the JDF node has Template=<see langword="true"/> or
        /// <see langword="false"/> if Template=<see langword="false"/>, Template attribute is
        /// invalid or the value is <see langword="null"/>.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static bool IsTemplate(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            var isTemplate = jdfNode.GetAttributeValueAsBoolOrNull("Template");
            return isTemplate != null ? isTemplate.Value : false;
        }

        /// <summary>
        /// Gets the types of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string[] GetJdfTypes(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            var typesString = element.GetAttributeFromJdfElement("Types");

            if (string.IsNullOrWhiteSpace(typesString)) {
                return null;
            }

            return typesString.Split(' ');
        }

        /// <summary>
        /// Gets the job id of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJobId(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfElement("JobID");
        }

        /// <summary>
        /// Sets the job id of the jdf node to the id value
        /// given.  If no id is provided, a unique value 
        /// is generated.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static XElement SetJobId(this XElement element, string id = null) {
            ParameterCheck.ParameterRequired(element, "element");
            element.ThrowExceptionIfNotJdfElement();

            if (id == null) {
                id = Globals.CreateUniqueId("J_");
            }

            element.SetAttributeValue("JobID", id);

            return element;
        }

        /// <summary>
        /// Sets the job part id of the jdf node to
        /// the id value given.  If no id is provied,
        /// a unique valuie is generated.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="jobPartId"></param>
        /// <returns></returns>
        public static XElement SetJobPartId(this XElement element, string jobPartId = null) {
            ParameterCheck.ParameterRequired(element, "element");
            element.ThrowExceptionIfNotJdfElement();

            if (jobPartId == null) {
                jobPartId = Globals.CreateUniqueId("JP_");
            }

            element.SetAttributeValue("JobPartID", jobPartId);

            return element;
        }

        /// <summary>
        /// Gets the job part of the node.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetJobPartId(this XElement element) {
            ParameterCheck.ParameterRequired(element, "element");

            return element.GetAttributeFromJdfElement("JobPartID");
        }

        static string GetAttributeFromJdfElement(this XElement element, string attributeName) {
            ParameterCheck.ParameterRequired(element, "element");
            ParameterCheck.StringRequiredAndNotWhitespace(attributeName, "attributeName");

            element.ThrowExceptionIfNotJdfElement();

            return element.GetAttributeValueOrNull(attributeName);
        }

        /// <summary>
        /// Make the JDF node an intent node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static XElement MakeJdfElementAnIntent(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            jdfNode.SetTypeAndTypes("Product");

            return jdfNode;
        }

        /// <summary>
        /// Make the JDF node a process group node
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <returns></returns>
        public static XElement MakeJdfElementAProcessGroup(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            jdfNode.SetTypeAndTypes("ProcessGroup");

            return jdfNode;
        }

        /// <summary>
        /// Make the JDF node a process
        /// </summary>
        /// <returns></returns>
        public static XElement MakeJdfElementAProcess(this XElement jdfNode, params string[] types) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            jdfNode.ThrowExceptionIfNotJdfElement();

            jdfNode.SetTypeAndTypes(types);

            return jdfNode;
        }

        /// <summary>
        /// Throws an ArgumentException if the given node is not a JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        public static void ThrowExceptionIfNotJdfElement(this XElement jdfNode) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");

            if (!jdfNode.IsJdfElement()) {
                throw new ArgumentException(string.Format(Messages.CanOnlyOperateOnJdfNode,
                                                          jdfNode.Name));
            }
        }

        /// <summary>
        /// Set type and optionally types of a JDF node.
        /// </summary>
        /// <param name="jdfNode"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static XElement SetTypeAndTypes(this XElement jdfNode, params string[] types) {
            ParameterCheck.ParameterRequired(jdfNode, "jdfNode");
            ThrowExceptionIfNotJdfElement(jdfNode);

            if (types == null || types.Length == 0) {
                jdfNode.SetAttributeValue("Type", ProcessType.ProcessGroup);
                jdfNode.SetXsiType(ProcessType.XsiJdfElementType(ProcessType.ProcessGroup).ToString());
            }
            if (types.Length == 1) {
                jdfNode.SetAttributeValue("Type", types[0]);
                jdfNode.SetXsiType(ProcessType.XsiJdfElementType(types[0]).ToString());
            }
            else {
                jdfNode.SetAttributeValue("Type", ProcessType.Combined);
                jdfNode.SetXsiType(ProcessType.XsiJdfElementType(ProcessType.Combined));
                jdfNode.SetAttributeValue("Types", string.Join(" ", types));
            }


            return jdfNode;
        }

        /// <summary>
        /// Gets all resources with a particular usage associated with a JDF element.
        /// </summary>
        /// <param name="jdfElement">The JDF element to search</param>
        /// <param name="usage">The resorce usage -- input or output</param>
        /// <param name="resourceRoot">The root element for finding resources - default is the document root</param>
        /// <returns>An IEnumerable{XElement} containing a list of resources with the correct usage.  
        /// The list will be empty if there are no resources linked with the given usage.</returns>
        /// <exception cref="PreconditionException">If the given XElement is not a JDf element.</exception>
        public static IEnumerable<XElement> ResourcesByUsage(this XElement jdfElement, ResourceUsage usage, XElement resourceRoot = null) {
            ParameterCheck.ParameterRequired(jdfElement, "jdfElement");
            jdfElement.ThrowExceptionIfNotJdfElement();

            var linkPool = jdfElement.Element(Element.ResourceLinkPool);

            if (linkPool == null)
                return new List<XElement>();

            var qualifiedLinkIds = (from resourceLink in linkPool.Elements()
                                    where
                                        resourceLink.Attribute("Usage") != null &&
                                        resourceLink.Attribute("Usage").Value == usage.ToString() &&
                                        resourceLink.Attribute("rRef") != null
                                    select resourceLink.Attribute("rRef").Value);

            var resources = (from resource in (resourceRoot ?? linkPool.Document.Root).Descendants()
                             where resource.Attribute("ID") != null &&
                                   qualifiedLinkIds.Contains(resource.Attribute("ID").Value)
                             select resource);
            return resources;
        }

        /// <summary>
        /// Create a ticket from a document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the document has
        /// a root element that is not a JDF element.</exception>
        public static Ticket ToTicket(this XDocument document)
        {
            ParameterCheck.ParameterRequired(document, "document");
            if (document.Root != null)
            {
                document.Root.ThrowExceptionIfNotJdfElement();
            }

            var ticket = new Ticket();
            if (document.Root != null)
            {
                ticket.Add(document.Root);
            }

            return ticket;
        }
    }
}