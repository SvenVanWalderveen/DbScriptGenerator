using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DbScriptGeneratorDll
{
    public class ResponseEnvelopeWithDataResult<T>
    {
        public ResponseEnvelopeWithDataResult()
        {

        }
        public ResponseEnvelopeWithDataResult(Exception exception)
        {
            this.Exception = exception;
            this.CallSuccessfull = false;
        }
        public ResponseEnvelopeWithDataResult(T data)
        {
            this.DataResult = data;
            this.CallSuccessfull = true;
        }



        public T DataResult { get; set; }
        public bool CallSuccessfull { get; set; }
        public Exception Exception { get; set; }
    }

    public class ResponseEnvelope
    {
        MethodBase? _errorMethod;
        string _errorMessage;
        ResponseEnvelopeStatusCode _statusCode;
        Exception _exception;

        public ResponseEnvelope()
        {
            _statusCode = ResponseEnvelopeStatusCode.Succeeded;
        }
        public ResponseEnvelope(Exception ex)
        {
            _exception = ex;
        }





        public string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(_errorMessage))
                {
                    return null;
                }
                if (_errorMethod == null)
                {
                    return _errorMessage;
                }
                else
                {
                    return string.Format("{0} (Method: {1})", _errorMessage, _errorMethod);
                }
            }
        }
        public Exception Exception
        {
            get
            {
                return this._exception;
            }
        }
        public bool CallSuccessfull
        {
            get
            {
                return _statusCode == ResponseEnvelopeStatusCode.Succeeded;
            }
        }

    }
    public enum ResponseEnvelopeStatusCode
    {
        Failed = 0,
        Succeeded = 1
    }
}
