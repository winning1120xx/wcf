// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

using System.Xml;

namespace System.ServiceModel.Security
{
    internal abstract class TrustDriver
    {
        // issued tokens control        
        public virtual bool IsIssuedTokensSupported
        {
            get
            {
                return false;
            }
        }

        // issued tokens feature        
        public virtual string IssuedTokensHeaderName
        {
            get
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.TrustDriverVersionDoesNotSupportIssuedTokens));
            }
        }

        // issued tokens feature        
        public virtual string IssuedTokensHeaderNamespace
        {
            get
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.TrustDriverVersionDoesNotSupportIssuedTokens));
            }
        }

        // session control
        public virtual bool IsSessionSupported
        {
            get
            {
                return false;
            }
        }

        public abstract XmlDictionaryString RequestSecurityTokenAction { get; }

        public abstract XmlDictionaryString RequestSecurityTokenResponseAction { get; }

        public abstract XmlDictionaryString RequestSecurityTokenResponseFinalAction { get; }

        // session feature
        public virtual string RequestTypeClose
        {
            get
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.TrustDriverVersionDoesNotSupportSession));
            }
        }

        public abstract string RequestTypeIssue { get; }

        // session feature
        public virtual string RequestTypeRenew
        {
            get
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.TrustDriverVersionDoesNotSupportSession));
            }
        }

        public abstract string ComputedKeyAlgorithm { get; }

        public abstract SecurityStandardsManager StandardsManager { get; }

        public abstract XmlDictionaryString Namespace { get; }

        // RST specific method
        public abstract RequestSecurityToken CreateRequestSecurityToken(XmlReader reader);

        // RSTR specific method
        public abstract RequestSecurityTokenResponse CreateRequestSecurityTokenResponse(XmlReader reader);

        // RSTRC specific method
        public abstract RequestSecurityTokenResponseCollection CreateRequestSecurityTokenResponseCollection(XmlReader xmlReader);

        public abstract bool IsAtRequestSecurityTokenResponse(XmlReader reader);

        public abstract bool IsAtRequestSecurityTokenResponseCollection(XmlReader reader);

        public abstract bool IsRequestedSecurityTokenElement(string name, string nameSpace);

        public abstract bool IsRequestedProofTokenElement(string name, string nameSpace);

        public abstract T GetAppliesTo<T>(RequestSecurityToken rst, XmlObjectSerializer serializer);

        public abstract T GetAppliesTo<T>(RequestSecurityTokenResponse rstr, XmlObjectSerializer serializer);

        public abstract void GetAppliesToQName(RequestSecurityToken rst, out string localName, out string namespaceUri);

        public abstract void GetAppliesToQName(RequestSecurityTokenResponse rstr, out string localName, out string namespaceUri);

        public abstract bool IsAppliesTo(string localName, string namespaceUri);

        // RSTR specific method
        public abstract byte[] GetAuthenticator(RequestSecurityTokenResponse rstr);

        // RST specific method
        public abstract BinaryNegotiation GetBinaryNegotiation(RequestSecurityToken rst);

        // RSTR specific method
        public abstract BinaryNegotiation GetBinaryNegotiation(RequestSecurityTokenResponse rstr);

        // RST specific method
        public abstract SecurityToken GetEntropy(RequestSecurityToken rst, SecurityTokenResolver resolver);

        // RSTR specific method
        public abstract SecurityToken GetEntropy(RequestSecurityTokenResponse rstr, SecurityTokenResolver resolver);

        public abstract void OnRSTRorRSTRCMissingException();

        // RST specific method
        public abstract void WriteRequestSecurityToken(RequestSecurityToken rst, XmlWriter w);

        // RSTR specific method
        public abstract void WriteRequestSecurityTokenResponse(RequestSecurityTokenResponse rstr, XmlWriter w);

        // RSTR Collection method
        public abstract void WriteRequestSecurityTokenResponseCollection(RequestSecurityTokenResponseCollection rstrCollection, XmlWriter writer);

        // Federation proxy creation
        public abstract IChannelFactory<IRequestChannel> CreateFederationProxy(EndpointAddress address, Binding binding, KeyedByTypeCollection<IEndpointBehavior> channelBehaviors);
    }
}
