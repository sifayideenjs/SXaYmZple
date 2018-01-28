using Quotation.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Utilities
{
    public static class RecentListUtility
    {
        public static void AddRecentData(RecentItem recentItem, string recentFileName)
        {
            RecentListModel recentListModel = null;
            string filePath = GetRecentFilePath(recentFileName);
            if (!File.Exists(filePath))
            {
                recentListModel = new RecentListModel();
            }
            try
            {
                recentListModel = XmlParser.ConvertFromXml<RecentListModel>(filePath);
            }
            catch
            {
                recentListModel = new RecentListModel();
            }

            recentListModel.Add(recentItem);
            XmlParser.ConvertToXml<RecentListModel>(recentListModel, filePath);
        }

        internal static void SaveRecentData(RecentListModel recentListModel, string recentFileName)
        {
            string filePath = GetRecentFilePath(recentFileName);
            XmlParser.ConvertToXml<RecentListModel>(recentListModel, filePath);
        }

        public static RecentListModel ReadRecentList(string recentFileName)
        {
            string filePath = GetRecentFilePath(recentFileName);
            if (!File.Exists(filePath))
            {
#if DEBUG
                var recentList = new RecentListModel();
                recentList.Add(new RecentItem() { QuotationNo = "1234567", NRIC = "XXX-YYY" });
                recentList.Add(new RecentItem() { QuotationNo = "1234568", NRIC = "YYY-ZZZ" });
                recentList.Add(new RecentItem() { QuotationNo = "1234569", NRIC = "XXX-ZZZ" });
                return recentList;
#else
                return new RecentListModel();
#endif
            }
            try
            {
                RecentListModel recentListModel = XmlParser.ConvertFromXml<RecentListModel>(filePath);
                return recentListModel;
            }
            catch
            {
                return new RecentListModel();
            }
        }

        public static void DeleteRecentList(string recentFileName)
        {
            string filePath = GetRecentFilePath(recentFileName);
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch(IOException)
                {
                }
            }
        }

        private static string GetRecentFilePath(string recentFileName)
        {
            Assembly asm = Assembly.GetEntryAssembly();
            object[] attr = (asm.GetCustomAttributes(typeof(GuidAttribute), true));
            Guid appGuid = new Guid((attr[0] as GuidAttribute).Value);

            string folderBase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dir = string.Format(@"{0}\{1}\", folderBase, appGuid.ToString("B").ToUpper());
            string appDataDirectory = CheckDir(dir);
            string recentDataPath = Path.Combine(appDataDirectory, recentFileName);
            return recentDataPath;
        }

        private static string CheckDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }
}
