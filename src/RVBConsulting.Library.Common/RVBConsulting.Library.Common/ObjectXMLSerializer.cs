using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace RVBConsulting.Library.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public static partial class ObjectXMLSerializer<TEntity> where TEntity : class
    {
        /// <summary>
        /// Generic file write routine in binary format
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="obj">Object to insert into file</param>
        public static void SaveToBinFile(string fileName, TEntity obj)
        {
            try
            {
                var streamWriter = new StreamWriter(fileName);
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(streamWriter.BaseStream, obj);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="obj"></param>
        public static void SaveToStrFile(string fileName, TEntity obj)
        {
            try
            {
                var fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                var soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fileStream, obj);

                fileStream.Close();
                fileStream.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Generic binary file read routine
        /// </summary>
        /// <param name="fileName">Name of the file to be recovered</param>
        /// <returns>Object</returns>
        public static TEntity LoadFromBinFile(string fileName)
        {
            try
            {
                var streamReader = new StreamReader(fileName);
                var binaryFormatter = new BinaryFormatter();
                var tipo = (TEntity)binaryFormatter.Deserialize(streamReader.BaseStream);
                streamReader.Close();
                return tipo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static TEntity Deserializar(string xml)
        {
            try
            {

                var reader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(TEntity));

                var tipo = (TEntity)serializer.Deserialize(reader);

                return tipo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Serializes an object
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>string formato XML</returns>
        public static string Serializar(TEntity obj)
        {
            var results = string.Empty;

            var writer = new StringWriter();

            var serializer = new XmlSerializer(obj.GetType());

            serializer.Serialize(writer, obj);

            results = writer.ToString();

            return results.Replace("utf-16", "utf-8"); //donotlocalize
        }
    }
}
