using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;
using System.Web.Configuration;
using System.Text;
using System.Globalization;
using System.Web.Caching;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using BiharIayAuth.API.Models;


namespace BiharIayAuth.API
{
    public class dbUtility
    {

        public static List<DrilldownData> GetDrilldownData(string value)
        {
            MySqlConnection scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand scmd = new MySqlCommand();
            scon.Open();
            scmd.Connection = scon;
            List<DrilldownData> drilldata = new List<DrilldownData>();
            string tval = value.Split(',')[0];
            int id = Convert.ToInt32(value.Split(',')[1]);
            try
            {
                scmd.CommandText = "";
                StringBuilder qsb;
                if (tval == "district")
                {
                    qsb = new StringBuilder();
                    qsb.Append("SELECT d.*, COUNT(DISTINCT(bf.bfid)) AS totalbf,COUNT(a.rid) AS totalrep,COALESCE(SUM(a.hlevel = 'Plinth Level'), 0) AS pl,COALESCE(SUM(a.hlevel = 'Lintel Level'), 0) AS ll");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Roof Level'), 0) AS rl,COALESCE(SUM(a.hlevel = 'Not Started'), 0) AS ns");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Completed'), 0) AS comp FROM iayreports a RIGHT JOIN benefs bf ON a.bfid=bf.bfid ");
                    qsb.Append("RIGHT JOIN panchayats p ON bf.pid=p.pid RIGHT JOIN blocks b ON p.bid=b.bid RIGHT JOIN districts d ON b.did=d.did GROUP BY d.did ORDER BY d.dname");
                    scmd.CommandText = qsb.ToString();
                }
                else if (tval == "block")
                {
                    qsb = new StringBuilder();
                    qsb.Append("SELECT b.*,COUNT(DISTINCT(bf.bfid)) AS totalbf,COUNT(a.rid) AS totalrep,COALESCE(SUM(a.hlevel = 'Plinth Level'), 0) AS pl,COALESCE(SUM(a.hlevel = 'Lintel Level'), 0) AS ll");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Roof Level'), 0) AS rl,COALESCE(SUM(a.hlevel = 'Not Started'), 0) AS ns");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Completed'), 0) AS comp FROM iayreports a RIGHT JOIN benefs bf ON a.bfid=bf.bfid ");
                    qsb.Append("RIGHT JOIN panchayats p ON bf.pid=p.pid RIGHT JOIN blocks b ON p.bid=b.bid RIGHT JOIN districts d ON b.did=d.did ");
                    qsb.Append("WHERE d.did=" + id + " GROUP BY b.bid ORDER BY b.bname");
                    scmd.CommandText = qsb.ToString();
                }
                else if (tval == "panchayat")
                {
                    qsb = new StringBuilder();
                    qsb.Append("SELECT p.*,COUNT(DISTINCT(bf.bfid)) AS totalbf,COUNT(a.rid) AS totalrep,COALESCE(SUM(a.hlevel = 'Plinth Level'), 0) AS pl,COALESCE(SUM(a.hlevel = 'Lintel Level'), 0) AS ll");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Roof Level'), 0) AS rl,COALESCE(SUM(a.hlevel = 'Not Started'), 0) AS ns");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Completed'), 0) AS comp FROM iayreports a RIGHT JOIN benefs bf ON a.bfid=bf.bfid ");
                    qsb.Append("RIGHT JOIN panchayats p ON bf.pid=p.pid RIGHT JOIN blocks b ON p.bid=b.bid ");
                    qsb.Append("WHERE b.bid=" + id + " GROUP BY p.pid ORDER BY p.pname");
                    scmd.CommandText = qsb.ToString();
                }
                else if (tval == "benef")
                {
                    qsb = new StringBuilder();
                    qsb.Append("SELECT bf.*,COUNT(DISTINCT(bf.bfid)) AS totalbf,COUNT(a.rid) AS totalrep,COALESCE(SUM(a.hlevel = 'Plinth Level'), 0) AS pl,COALESCE(SUM(a.hlevel = 'Lintel Level'), 0) AS ll");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Roof Level'), 0) AS rl,COALESCE(SUM(a.hlevel = 'Not Started'), 0) AS ns");
                    qsb.Append(",COALESCE(SUM(a.hlevel = 'Completed'), 0) AS comp FROM iayreports a RIGHT JOIN benefs bf ON a.bfid=bf.bfid ");
                    qsb.Append("RIGHT JOIN panchayats p ON bf.pid=p.pid ");
                    qsb.Append("WHERE p.pid=" + id + " GROUP BY bf.bfid ORDER BY bf.bfname");
                    scmd.CommandText = qsb.ToString();
                }
                scmd.Prepare();
                MySqlDataReader sdr = scmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        DrilldownData dData = new DrilldownData();
                        dData.TOTALBF = Convert.ToInt32(sdr.GetString("totalbf"));
                        dData.TOTALREP = Convert.ToInt32(sdr.GetString("totalrep"));
                        dData.NS = Convert.ToInt32(sdr.GetString("ns"));
                        dData.PL = Convert.ToInt32(sdr.GetString("pl"));
                        dData.LL = Convert.ToInt32(sdr.GetString("ll"));
                        dData.RL = Convert.ToInt32(sdr.GetString("rl"));
                        dData.COMP = Convert.ToInt32(sdr.GetString("comp"));
                        if (tval == "district")
                        {
                            dData.DISTRICT = new _District();
                            dData.DISTRICT.DID = Convert.ToInt32(sdr.GetString("did"));
                            dData.DISTRICT.DCODE = sdr.GetString("dcode");
                            dData.DISTRICT.DNAME = sdr.GetString("dname");
                        }
                        else if (tval == "block")
                        {
                            dData.BLOCK = new _Block();
                            dData.BLOCK.BID = Convert.ToInt32(sdr.GetString("bid"));
                            dData.BLOCK.BCODE = sdr.GetString("bcode");
                            dData.BLOCK.BNAME = sdr.GetString("bname");
                        }
                        else if (tval == "panchayat")
                        {
                            dData.PANCHAYAT = new _Panchayat();
                            dData.PANCHAYAT.PID = Convert.ToInt32(sdr.GetString("pid"));
                            dData.PANCHAYAT.PCODE = sdr.GetString("pcode");
                            dData.PANCHAYAT.PNAME = sdr.GetString("pname");
                        }
                        else if (tval == "benef")
                        {
                            dData.BENEF = new _Benefs();
                            dData.BENEF.BFID = Convert.ToInt32(sdr.GetString("bfid"));
                            dData.BENEF.BFCODE = sdr.GetString("bfcode");
                            dData.BENEF.BFNAME = sdr.GetString("bfname");
                        }
                        drilldata.Add(dData);
                    }
                }
                sdr.Close();
                sdr.Dispose();

            }
            catch (Exception ee)
            {

            }
            finally
            {
                if (scmd != null)
                    scmd.Dispose();
                if (scon.State == ConnectionState.Open)
                {
                    scon.Dispose();
                    scon.Close();
                }
            }
            return drilldata;
        }


        public static List<_IayForm> GetIayReports()
        {
            MySqlConnection scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand scmd = new MySqlCommand();
            scon.Open();
            scmd.Connection = scon;
            List<_IayForm> repList = new List<_IayForm>();
            try
            {
                scmd.CommandText = "SELECT a.*,d.*,b.*,p.*,bf.* FROM iayreports a INNER JOIN benefs bf ON a.bfid=bf.bfid INNER JOIN panchayats p ON bf.pid=p.pid INNER JOIN blocks b ON p.bid=b.bid INNER JOIN districts d ON b.did=d.did";
                scmd.Prepare();
                MySqlDataReader sdr = scmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        _IayForm iaydata = new _IayForm();
                        iaydata.FDATE = Convert.ToDateTime(sdr.GetString("fdate")).ToString("dd-MMM-yyyy hh:mm");
                        iaydata.DISTRICT.DID = Convert.ToInt32(sdr.GetString("did"));
                        repList.Add(iaydata);
                    }
                }
                sdr.Close();
                sdr.Dispose();

            }
            catch (Exception ee)
            {

            }
            finally
            {
                if (scmd != null)
                    scmd.Dispose();
                if (scon.State == ConnectionState.Open)
                {
                    scon.Dispose();
                    scon.Close();
                }
            }
            return repList;
        }
        public static int SaveIayInsReport(_IayForm iaydata)
        {
            MySqlConnection scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString + "; CharSet=utf8");
            MySqlCommand scmd = new MySqlCommand();
            scon.Open();
            scmd.Connection = scon;
            int ret = -1;
            try
            {
                scmd.CommandText = "insert into iayreports (bfid,fdate,hlevel,idate,remark) values(@bfid,@fdate,@hlevel,@idate,@remark)";
                scmd.Parameters.AddWithValue("bfid", iaydata.BENEF.BFID);
                scmd.Parameters.AddWithValue("fdate", DateTime.Now);
                scmd.Parameters.AddWithValue("hlevel", iaydata.HOUSELEVEL);
                scmd.Parameters.AddWithValue("idate", Convert.ToDateTime(iaydata.IDATE).ToString("yyyy-MM-dd"));
                scmd.Parameters.AddWithValue("remark", iaydata.REMARK);
                scmd.Prepare();
                scmd.ExecuteNonQuery();
                ret = Convert.ToInt32(scmd.LastInsertedId);
            }
            catch (Exception ee)
            {
                ret = -1;
            }
            finally
            {
                if (scmd != null)
                    scmd.Dispose();
                if (scon.State == ConnectionState.Open)
                {
                    scon.Dispose();
                    scon.Close();
                }
            }
            return ret;
        }

        public static List<_District> GetDistricts()
        {
            MySqlConnection scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand scmd = new MySqlCommand();
            scon.Open();
            scmd.Connection = scon;
            List<_District> distList = new List<_District>();
            try
            {
                scmd.CommandText = "SELECT * from districts";
                scmd.Prepare();
                MySqlDataReader sdr = scmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        _District dist = new _District();
                        dist.DID = Convert.ToInt32(sdr.GetString(0));
                        dist.DCODE = sdr.GetString(1);
                        dist.DNAME = sdr.GetString(2);
                        distList.Add(dist);
                    }
                }
                sdr.Close();
                sdr.Dispose();

            }
            catch (Exception ee)
            {

            }
            finally
            {
                if (scmd != null)
                    scmd.Dispose();
                if (scon.State == ConnectionState.Open)
                {
                    scon.Dispose();
                    scon.Close();
                }
            }
            return distList;
        }

        public static List<_Block> GetBlocks(int did)
        {
            MySqlConnection scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand scmd = new MySqlCommand();
            scon.Open();
            scmd.Connection = scon;
            List<_Block> blkList = new List<_Block>();
            try
            {
                scmd.CommandText = "SELECT * from blocks where did=" + did;
                scmd.Prepare();
                MySqlDataReader sdr = scmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        _Block blk = new _Block();
                        blk.BID = Convert.ToInt32(sdr.GetString(0));
                        blk.DID = Convert.ToInt32(sdr.GetString(1));
                        blk.BCODE = sdr.GetString(2);
                        blk.BNAME = sdr.GetString(3);
                        blkList.Add(blk);
                    }
                }
                sdr.Close();
                sdr.Dispose();

            }
            catch (Exception ee)
            {

            }
            finally
            {
                if (scmd != null)
                    scmd.Dispose();
                if (scon.State == ConnectionState.Open)
                {
                    scon.Dispose();
                    scon.Close();
                }
            }
            return blkList;
        }

        public static List<_Panchayat> GetPanchayats(int bid)
        {
            MySqlConnection scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand scmd = new MySqlCommand();
            scon.Open();
            scmd.Connection = scon;
            List<_Panchayat> pancList = new List<_Panchayat>();
            try
            {
                scmd.CommandText = "SELECT * from panchayats where bid=" + bid;
                scmd.Prepare();
                MySqlDataReader sdr = scmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        _Panchayat panc = new _Panchayat();
                        panc.PID = Convert.ToInt32(sdr.GetString(0));
                        panc.BID = Convert.ToInt32(sdr.GetString(1));
                        panc.PCODE = sdr.GetString(2);
                        panc.PNAME = sdr.GetString(3);
                        pancList.Add(panc);
                    }
                }
                sdr.Close();
                sdr.Dispose();

            }
            catch (Exception ee)
            {

            }
            finally
            {
                if (scmd != null)
                    scmd.Dispose();
                if (scon.State == ConnectionState.Open)
                {
                    scon.Dispose();
                    scon.Close();
                }
            }
            return pancList;
        }

        public static List<_Benefs> GetBenefs(int pid)
        {
            MySqlConnection scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand scmd = new MySqlCommand();
            scon.Open();
            scmd.Connection = scon;
            List<_Benefs> benList = new List<_Benefs>();
            try
            {
                scmd.CommandText = "SELECT * from benefs where pid=" + pid;
                scmd.Prepare();
                MySqlDataReader sdr = scmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        _Benefs ben = new _Benefs();
                        ben.BFID = Convert.ToInt32(sdr.GetString(0));
                        ben.PID = Convert.ToInt32(sdr.GetString(1));
                        ben.BFCODE = sdr.GetString(2);
                        ben.BFNAME = sdr.GetString(3);
                        benList.Add(ben);
                    }
                }
                sdr.Close();
                sdr.Dispose();

            }
            catch (Exception ee)
            {

            }
            finally
            {
                if (scmd != null)
                    scmd.Dispose();
                if (scon.State == ConnectionState.Open)
                {
                    scon.Dispose();
                    scon.Close();
                }
            }
            return benList;
        }
    }
}