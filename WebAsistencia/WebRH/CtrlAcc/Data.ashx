<%@ WebHandler Language="C#" Class="Data" %>

using System;
using System.Web;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

public class Data : IHttpHandler {

    private jsonReturn _jsonRet = new jsonReturn();
    private string _param = string.Empty;
        
    public class item {
        public string id;
        public string text;
        public void setData( string _id, string _text )
        {
            this.id = _id; this.text = _text;
        }
    }
    
    public class jsonReturn {
        public item[] results;       
    }

    public void ProcessRequest(HttpContext context){
        this.saveParams(context);
        this._jsonRet.results = this.getData();
        this.processData(context);
    }

    public bool IsReusable {
        get { return false; }
    }    

    private void processData(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write(JsonConvert.SerializeObject(this._jsonRet));
    }

    private void saveParams(HttpContext context)
    {
        if (!(context.Request.Params["q"] == null))
            _param = context.Request.Params["q"];
    }
        
    private item[] getData(){
        List<item> lst = new List<item>();
        for (int i=1; i <= 20; i++){
            item itm = new item();
            itm.setData(i.ToString(), "Option " + i.ToString());
            lst.Add(itm);
        }
        List<item> lst_result = new List<item>();
        foreach (item itm in lst)
        {
            if (itm.text.Contains(_param))
                lst_result.Add(itm);
        }        
        return lst_result.ToArray();
    }


    



    
    
}