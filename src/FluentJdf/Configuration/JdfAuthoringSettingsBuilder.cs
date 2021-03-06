﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Configuration
{
    /// <summary>
    /// Fluent setting for authoring settings
    /// </summary>
    public class JdfAuthoringSettingsBuilder : SettingsBuilderBase {
        JdfAuthoringSettings authoringSettings;

        internal JdfAuthoringSettingsBuilder(IFluentJdfLibrary fluentJdfLibrary, JdfAuthoringSettings authoringSettings) : base(fluentJdfLibrary) {
            ParameterCheck.ParameterRequired(authoringSettings, "authoringSettings");

            this.authoringSettings = authoringSettings;
        }

        /// <summary>
        /// Sets option for generating job id
        /// </summary>
        /// <param name="generateJobId"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder GenerateJobId(bool generateJobId) {
            authoringSettings.GenerateJobId = generateJobId;
            return this;
        }

        /// <summary>
        /// Sets options for generating job part id.
        /// </summary>
        /// <param name="generatejobPartId"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder GenerateJobPartId(bool generatejobPartId) {
            authoringSettings.GenerateJobPartId = generatejobPartId;
            return this;
        }

        /// <summary>
        /// Sets option for the default agent name for audits.
        /// </summary>
        /// <param name="agentName"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder AgentName(string agentName) {
            authoringSettings.AgentName = agentName;
            return this;
        }

        /// <summary>
        /// Sets the default agent version for audits.
        /// </summary>
        /// <param name="agentVersion"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder AgentVersion(string agentVersion)
        {
            authoringSettings.AgentVersion = agentVersion;
            return this;
        }

        /// <summary>
        /// Sets the default author for audits.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder Author(string author)
        {
            authoringSettings.Author = author;
            return this;
        }

        /// <summary>
        /// Sets option for automatically generating a create audit on new root JDF nodes.
        /// </summary>
        /// <param name="createAuditOnNewRootJdf"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder CreateAuditOnNewRootJdf(bool createAuditOnNewRootJdf)
        {
            authoringSettings.CreateAuditOnNewRootJdf = createAuditOnNewRootJdf;
            return this;
        }

        /// <summary>
        /// Sets the default JDF version placed in newly created JDF and JMF root nodes.
        /// </summary>
        /// <param name="jdfVersion"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder JdfVersion(string jdfVersion) {
            ParameterCheck.StringRequiredAndNotWhitespace(jdfVersion, "jdfVersion");

            authoringSettings.JdfVersion = jdfVersion;
            return this;
        }

        /// <summary>
        /// Sets the JMF sender id.
        /// </summary>
        /// <param name="senderId"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder SenderId(string senderId) {
            if (string.IsNullOrWhiteSpace(senderId)) {
                senderId = null;
            }

            authoringSettings.SenderId = senderId;
            return this;
        }
    }

}
