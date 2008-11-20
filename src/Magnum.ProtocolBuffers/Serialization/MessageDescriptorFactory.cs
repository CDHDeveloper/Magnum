
// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.ProtocolBuffers.Serialization
{
    using System;
    using System.Collections.Generic;
    using Common.Reflection;
    using Internal;

    public class MessageDescriptorFactory
    {
        private readonly Dictionary<Type, IMessageDescriptor> _descriptors = new Dictionary<Type, IMessageDescriptor>();

        public IMessageDescriptor Build<TMessage>(IMap<TMessage> map) where TMessage : class, new()
        {
            if (_descriptors.ContainsKey(typeof(TMessage)))
                return _descriptors[typeof(TMessage)];

            IMessageDescriptor<TMessage> desc = new MessageDescriptor<TMessage>();

            foreach (var field in map.Fields)
            {
                var tag = field.NumberTag;
                var fp = new FastProperty<TMessage>(field.PropertyInfo);

                desc.AddProperty(tag, fp, field.FieldType);
            }

            _descriptors.Add(typeof(TMessage), desc);
            return desc;
        }
    }
}