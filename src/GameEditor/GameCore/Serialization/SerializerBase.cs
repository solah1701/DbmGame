using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace GameCore.Serialization
{
    [DataContract()]
    public abstract class SerializerBase<T>
    {
        private IList<Type> knownTypes = new List<Type>();

        public abstract void AddKnownTypes(IList<Type> knownTypes);

        public void WriteObject(Stream stream)
        {
            if (knownTypes == null) knownTypes = new List<Type>();
            AddKnownTypes(knownTypes);
            var ser = new DataContractSerializer(typeof(T), knownTypes);
            ser.WriteObject(stream, this);
        }

        public T ReadObject(Stream stream)
        {
            if (knownTypes == null) knownTypes = new List<Type>();
            AddKnownTypes(knownTypes);
            var ser = new DataContractSerializer(typeof(T), knownTypes);
            return (T)ser.ReadObject(stream);
        }
    }
}
