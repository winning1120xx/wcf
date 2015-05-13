// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml;

namespace System.IdentityModel
{
    internal interface ISecurityElement
    {
        bool HasId { get; }

        string Id { get; }

        void WriteTo(XmlDictionaryWriter writer, DictionaryManager dictionaryManager);
    }
}
