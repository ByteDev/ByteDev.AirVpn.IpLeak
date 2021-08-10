using System;
using System.Runtime.Serialization;

namespace ByteDev.AirVpn.IpLeak
{
    /// <summary>
    /// Represents an error occurring in the IP Leak client.
    /// </summary>
    [Serializable]
    public class IpLeakClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException" /> class.
        /// </summary>
        public IpLeakClientException() : base("Error occured within the IP Leak client.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public IpLeakClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public IpLeakClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.AirVpn.IpLeak.IpLeakClientException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected IpLeakClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}