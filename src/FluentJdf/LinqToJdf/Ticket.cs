﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using FluentJdf.LinqToJdf.Builder.Jdf;
using FluentJdf.LinqToJdf.Builder.Jmf;
using FluentJdf.Resources;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Logging;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Starting point for creating JDF tickets.
    /// </summary>
    public class Ticket : FluentJdfDocumentBase {
        ILog logger = LogManager.GetLogger(typeof(FluentJdfDocumentBase));

        /// <summary>
        /// Constructor.
        /// </summary>
        internal Ticket() {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="source"></param>
        public Ticket(Ticket source) {
            ParameterCheck.ParameterRequired(source, "source");

            if (source.Root != null) {
                Add(new XElement(source.Root));
            }
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="document"></param>
        public Ticket(XDocument document)
            : base(document) {
            document.Root.ThrowExceptionIfNotJdfElement();
        }

        /// <summary>
        /// Create a ticket from a template in a file.
        /// </summary>
        /// <param name="templateFileName"></param>
        /// <returns></returns>
        public static GeneratedTicketTemplateSelectionBuilder CreateFromTemplate(string templateFileName) {
            return new GeneratedTicketTemplateSelectionBuilder(templateFileName);
        }

        /// <summary>
        /// Create a ticket from a template in a stream.
        /// </summary>
        /// <param name="templateStream"></param>
        /// <returns></returns>
        public static GeneratedTicketTemplateSelectionBuilder CreateFromTemplate(Stream templateStream) {
            return new GeneratedTicketTemplateSelectionBuilder(templateStream);
        }

        /// <summary>
        /// Creates a ticket from a template in an XDocument.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static GeneratedTicketTemplateSelectionBuilder CreateFromTemplate(XDocument document) {
            var stream = new TempFileStream();
            document.Save(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return CreateFromTemplate(stream);
        }

        /// <summary>
        /// Loads the ticket from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public new static Ticket Load(Stream stream) {
            return new Ticket(XDocument.Load(stream));
        }

        /// <summary>
        /// Loads the ticket from a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Ticket Load(Stream stream, LoadOptions options) {
            return new Ticket(XDocument.Load(stream, options));
        }

        /// <summary>
        /// Loads the ticket from a TextReader
        /// </summary>
        /// <param name="textReader"></param>
        /// <returns></returns>
        public new static Ticket Load(TextReader textReader) {
            return new Ticket(XDocument.Load(textReader));
        }

        /// <summary>
        /// Loads the ticket from a TextReader
        /// </summary>
        /// <param name="textReader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Ticket Load(TextReader textReader, LoadOptions options) {
            return new Ticket(XDocument.Load(textReader, options));
        }

        /// <summary>
        /// Loads the ticket from a XmlReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public new static Ticket Load(XmlReader reader) {
            return new Ticket(XDocument.Load(reader));
        }

        /// <summary>
        /// Loads the ticket from a XmlReader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Ticket Load(XmlReader reader, LoadOptions options) {
            return new Ticket(XDocument.Load(reader, options));
        }

        /// <summary>
        /// Loads the ticket from a file.
        /// </summary>
        /// <returns></returns>
        public new static Ticket Load(string uri) {
            return new Ticket(XDocument.Load(uri));
        }

        /// <summary>
        /// Loads the ticket from a file.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Ticket Load(string uri, LoadOptions options) {
            return new Ticket(XDocument.Load(uri, options));
        }

        /// <summary>
        /// Parses xml into a message.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public new static Ticket Parse(string text) {
            return XDocument.Parse(text).ToTicket();
        }

        /// <summary>
        ///  Parses xml into a message.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public new static Ticket Parse(string text, LoadOptions options) {
            return XDocument.Parse(text, options).ToTicket();
        }

        /// <summary>
        /// Gets the builder for the root.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder ModifyJdfNode() {
            if (Root == null || !Root.IsJdfElement()) {
                throw new Exception(Messages.Ticket_ModifyJdfNode_RootMustExistAndBeJdf);
            }

            return new JdfNodeBuilder(Root);
        }

        /// <summary>
        /// Create a new JDF intent ticket.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateIntent() {
            return new JdfNodeBuilder(new Ticket(), ProcessType.Intent);
        }

        /// <summary>
        /// Create a new JDF ticket with a process node at the root.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateProcess(params string[] types) {
            if (types == null || types.Length == 0) {
                throw new ArgumentException(Messages.AtLeastOneProcessMustBeSpecified);
            }
            return new JdfNodeBuilder(new Ticket(), types);
        }

        /// <summary>
        /// Create a new JDF ticket with a gray box (process group with types) at the root.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateGrayBox(params string[] types) {
            if (types == null || types.Length == 0) {
                throw new ArgumentException(Messages.AtLeastOneProcessMustBeSpecified);
            }
            return new JdfNodeBuilder(new Ticket(), true, types);
        }

        /// <summary>
        /// Create a new JDF ticket with a process group node at the root.
        /// </summary>
        /// <returns></returns>
        public static JdfNodeBuilder CreateProcessGroup() {
            return new JdfNodeBuilder(new Ticket(), ProcessType.ProcessGroup);
        }

        /// <summary>
        /// Validate the document.
        /// </summary>
        /// <param name="addSchemaInfo">True adds default elements, default attributes and schema info to the ticket.  False leaves this alone.  Default is true.</param>
        /// <param name="workAroundMSBug">True works around an issue in the .NET framework that causes validation to work improperly on schema types that inherit 
        /// from an abstract base class if the document is created via node authoring code instead of by Parse or Load methods.  Default is true.</param>
        public Ticket ValidateJdf(bool addSchemaInfo = true, bool workAroundMSBug = true) {
            validator.Validate(addSchemaInfo, workAroundMSBug);
            return this;
        }
    }
}