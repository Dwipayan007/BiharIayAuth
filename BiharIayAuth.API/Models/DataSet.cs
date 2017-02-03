using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiharIayAuth.API.Models
{
    public class _District
    {
        public int DID;
        public string DCODE;
        public string DNAME;
    }

    public class _Block
    {
        public int BID;
        public int DID;
        public string BCODE;
        public string BNAME;
    }

    public class _Panchayat
    {
        public int PID;
        public int BID;
        public string PCODE;
        public string PNAME;
    }

    public class _Benefs
    {
        public int BFID;
        public int PID;
        public string BFCODE;
        public string BFNAME;
    }
}