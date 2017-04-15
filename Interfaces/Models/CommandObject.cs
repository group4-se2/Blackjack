using Common.Lib.Interfaces;
using System;
using System.Collections.Generic;

namespace Common.Lib.Models
{
    public class CommandObject
    {
        //private Object _payload = new Object();

        public Command Command { get; set; }
        public Response Response { get; set; }
        public string Message { get; set; }
        public IList<IPlayer> Players { get; set; }
        //public Object Payload
        //{
        //    get
        //    {
        //        return GetPayload();
        //    }
        //    set
        //    {
        //        _payload = value;
        //    }
        //}

        //private Object GetPayload()
        //{
        //    if (_payload.GetType() == typeof(JObject))
        //    {
        //        return ((JObject)_payload).ToObject<Player>();
        //    }
        //    else if (_payload.GetType() == typeof(JArray))
        //    {
        //        return ((JArray)_payload).ToObject<List<Player>>();
        //    }
        //    else
        //    {
        //        return _payload;
        //    }
        //}
    }
}
