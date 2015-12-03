using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MyOPC;
using System.Drawing.Drawing2D;

namespace BLLayer
{
    class opcService
    {
        public static OPCCreate OPC = null; 
        public opcService()
        {
            try
            {
                OPC = new OPCCreate();
                OPC.EventDataChanged += new EventDataChanged(OnEventDataChanged);
                OPC.Run();
            }
            catch (Exception ex)
            {
                //Log.ErrLog.Error("OPC Server连接失败:" + ex.Message);
                //MessageBoxEx.Show("OPC Server连接失败，请检查PLC是否正常通讯。");
            }
        }

        private void OnEventDataChanged(object objItem, object objValue)
        {
            //Log.OPCLog.InfoFormat("进入OnEventDataChanged事件,OPC变量为：{0},值为：{1}", objItem, objValue);
            try
            {
                int itemCode = Convert.ToInt32(objItem);
                string itemValue = objValue.ToString();
                //BeginInvoke((MethodInvoker)delegate() { DoOPCEvent(itemCode, itemValue); });
            }
            catch (Exception ex)
            {
                //recordMessage("DataChanged事件处理错误:" + ex.Message);
            }
        }
    }
}
