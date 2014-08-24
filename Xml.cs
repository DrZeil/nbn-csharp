/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.IO;
namespace marekbar
{
    /// <summary>
    /// Xml serialization error type
    /// </summary>
    public enum XmlSerializeError
    {
        /// <summary>
        /// Argument not found - oops
        /// </summary>
        ARGUMENT_NULL,

        /// <summary>
        /// Argument went out of range
        /// </summary>
        ARGUMENT_OUT_OF_RANGE,

        /// <summary>
        /// Something wrong with argument
        /// </summary>
        ARGUMENT_ERROR,

        /// <summary>
        /// Path to file was to long
        /// </summary>
        PATH_TOO_LONG,

        /// <summary>
        /// There's no such dir
        /// </summary>
        MISSING_DIRECTORY,

        /// <summary>
        /// File not found
        /// </summary>
        MISSING_FILE,

        /// <summary>
        /// Security problem
        /// </summary>
        SECURITY_ERROR,

        /// <summary>
        /// Input/output error
        /// </summary>
        IO_ERROR,

        /// <summary>
        /// Oops
        /// </summary>
        NOT_SUPPORTED,

        /// <summary>
        /// Can't do that
        /// </summary>
        INVALID_OPERATION,

        /// <summary>
        /// Something else
        /// </summary>
        GENERAL,

        /// <summary>
        /// No errors, hurray
        /// </summary>
        NONE
    }

    /// <summary>
    /// Class to read from and save to xml 
    /// </summary>
    public class Xml
    {
        /// <summary>
        /// Error type
        /// </summary>
        public static XmlSerializeError Error = XmlSerializeError.NONE;

        /// <summary>
        /// Error message
        /// </summary>
        public static String Message = "";

        /// <summary>
        /// Save object to xml file
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="Source">object</param>
        /// <param name="filename">file</param>
        /// <returns>bool</returns>
        public static Boolean Save<T>(T Source, String filename)
        {
            var backup = filename + ".backup";

            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(backup);
                    try
                    {
                        File.Copy(filename, backup);
                    }
                    catch { }

                }
                using (var stream = new FileStream(filename, System.IO.FileMode.Create))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    serializer.Serialize(stream, Source);
                }
                Error = XmlSerializeError.NONE;
                if (File.Exists(filename))
                {
                    File.Delete(backup);
                }
                return true;
            }
            catch (ArgumentNullException e)
            {
                Error = XmlSerializeError.ARGUMENT_NULL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Error = XmlSerializeError.ARGUMENT_OUT_OF_RANGE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentException e)
            {
                Error = XmlSerializeError.ARGUMENT_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (System.Security.SecurityException e)
            {
                Error = XmlSerializeError.SECURITY_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (PathTooLongException e)
            {
                Error = XmlSerializeError.PATH_TOO_LONG;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (DirectoryNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_DIRECTORY;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (FileNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_FILE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (IOException e)
            {
                Error = XmlSerializeError.IO_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (NotSupportedException e)
            {
                Error = XmlSerializeError.NOT_SUPPORTED;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (InvalidOperationException e)
            {
                Error = XmlSerializeError.INVALID_OPERATION;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (Exception e)
            {
                Error = XmlSerializeError.GENERAL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            if (Error != XmlSerializeError.NONE)
            {
                if (File.Exists(filename) && File.Exists(backup))
                {
                    File.Delete(filename);
                    File.Copy(backup, filename);
                    File.Delete(backup);
                }
            }
            return false;
        }

        /// <summary>
        /// Restore object from xml
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="filename">file</param>
        /// <returns>object</returns>
        public static T Restore<T>(String filename) where T: new()
        {
            try
            {
                T data;
                using (var stream = new FileStream(filename, System.IO.FileMode.OpenOrCreate))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    data = (T)serializer.Deserialize(stream);
                }
                Error = XmlSerializeError.NONE;
                return data;
            }
            catch (ArgumentNullException e)
            {
                Error = XmlSerializeError.ARGUMENT_NULL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Error = XmlSerializeError.ARGUMENT_OUT_OF_RANGE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentException e)
            {
                Error = XmlSerializeError.ARGUMENT_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (System.Security.SecurityException e)
            {
                Error = XmlSerializeError.SECURITY_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (PathTooLongException e)
            {
                Error = XmlSerializeError.PATH_TOO_LONG;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (DirectoryNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_DIRECTORY;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (FileNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_FILE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (IOException e)
            {
                Error = XmlSerializeError.IO_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (NotSupportedException e)
            {
                Error = XmlSerializeError.NOT_SUPPORTED;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (InvalidOperationException e)
            {
                Error = XmlSerializeError.INVALID_OPERATION;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (Exception e)
            {
                Error = XmlSerializeError.GENERAL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            return new T();
        }

        /// <summary>
        /// Serialize object to xml string
        /// </summary>
        /// <typeparam name="T">T - object type</typeparam>
        /// <param name="dataToSerialize">T - object to serialize</param>
        /// <returns>String - xml</returns>
        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                using (StringWriter stringwriter = new System.IO.StringWriter())
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    serializer.Serialize(stringwriter, dataToSerialize);
                    return stringwriter.ToString();
                }
            }
            catch (ArgumentNullException e)
            {
                Error = XmlSerializeError.ARGUMENT_NULL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Error = XmlSerializeError.ARGUMENT_OUT_OF_RANGE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentException e)
            {
                Error = XmlSerializeError.ARGUMENT_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (System.Security.SecurityException e)
            {
                Error = XmlSerializeError.SECURITY_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (PathTooLongException e)
            {
                Error = XmlSerializeError.PATH_TOO_LONG;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (DirectoryNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_DIRECTORY;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (FileNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_FILE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (IOException e)
            {
                Error = XmlSerializeError.IO_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (NotSupportedException e)
            {
                Error = XmlSerializeError.NOT_SUPPORTED;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (InvalidOperationException e)
            {
                Error = XmlSerializeError.INVALID_OPERATION;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (Exception e)
            {
                Error = XmlSerializeError.GENERAL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            return "";
        }

        /// <summary>
        /// Restore object from xml string
        /// </summary>
        /// <typeparam name="T">T - object type</typeparam>
        /// <param name="xmlText">String - xml string</param>
        /// <returns>T - object restored from xml</returns>
        public static T Deserialize<T>(string xmlText) where T : new()
        {
            try
            {
            using (StringReader stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            }
            catch (ArgumentNullException e)
            {
                Error = XmlSerializeError.ARGUMENT_NULL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Error = XmlSerializeError.ARGUMENT_OUT_OF_RANGE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (ArgumentException e)
            {
                Error = XmlSerializeError.ARGUMENT_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (System.Security.SecurityException e)
            {
                Error = XmlSerializeError.SECURITY_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (PathTooLongException e)
            {
                Error = XmlSerializeError.PATH_TOO_LONG;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (DirectoryNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_DIRECTORY;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (FileNotFoundException e)
            {
                Error = XmlSerializeError.MISSING_FILE;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (IOException e)
            {
                Error = XmlSerializeError.IO_ERROR;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (NotSupportedException e)
            {
                Error = XmlSerializeError.NOT_SUPPORTED;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (InvalidOperationException e)
            {
                Error = XmlSerializeError.INVALID_OPERATION;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            catch (Exception e)
            {
                Error = XmlSerializeError.GENERAL;
                Message = e.Message + (e.InnerException != null ? "\n" + e.InnerException.Message : "");
            }
            return new T();
        }
    }
}
