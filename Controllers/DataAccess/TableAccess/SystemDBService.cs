/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             数据库操作信息数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess.SQLHELPER;
using System.Data;


namespace Controllers.DataAccess
{
    public class SystemDBService
    {
        /// <summary>
        /// 动态创建数据库
        /// </summary>
        /// <param name="serverIP">服务器IP</param>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="path">文件保存路径</param>
        /// <param name="size">初始大小</param>
        /// <param name="maxsize">最大大小</param>
        /// <returns></returns>
        public bool CreatDataBase(String serverIP, String user, String pwd, String dbName, String path, int size, int maxsize)
        {
            try
            {
                String sqlConString = "Server = " + serverIP + ";Database = master;User id=" + user + ";PWD=" + pwd;
                MySqlHelper msql = new MySqlHelper(sqlConString);
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CREATE DATABASE {0} ON PRIMARY", dbName);
                sb.AppendFormat("                     ( name={0},", dbName);
                sb.AppendFormat("                       filename ='{0}.mdf',", path + @"\" + dbName);
                sb.AppendFormat("                       size={0}mb,", size);
                sb.AppendFormat("                       maxsize={0}mb,", maxsize);
                sb.Append("                             filegrowth=10%");
                sb.Append(")");
                sb.Append("log on");
                sb.AppendFormat("                     ( name={0}_log,", dbName);
                sb.AppendFormat("                       filename ='{0}_log.ldf',", path + @"\" + dbName);
                sb.AppendFormat("                       size={0}mb,", size);
                sb.Append("                             filegrowth=1mb");
                sb.Append(")");
                msql.ExecDataBySql(sb.ToString());
                return CreatTables(serverIP, user, pwd, dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建数据库所有表
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private bool CreatTables(String serverIP, String user, String pwd, String dbName)
        {
            try
            {
                List<String> cmdTextList = new List<String>();
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(" CREATE TABLE [dbo].[BillInfo]( ");
                cmdText.Append(" [BIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdText.Append(" [BINo] [nvarchar](50) NOT NULL, ");
                cmdText.Append(" [BIName] [nvarchar](30) NOT NULL, ");
                cmdText.Append(" [BITIID] [int] NOT NULL, ");
                cmdText.Append(" [BISenderCode] [nvarchar](50) NOT NULL, ");
                cmdText.Append(" [BISender] [nvarchar](50) NOT NULL, ");
                cmdText.Append(" [BIReciverCode] [nvarchar](50) NOT NULL, ");
                cmdText.Append(" [BIReciver] [nvarchar](50) NOT NULL, ");
                cmdText.Append(" [BIAmount] [bigint] NOT NULL, ");
                cmdText.Append(" [BIIsEnable] [bit] NOT NULL, ");
                cmdText.Append(" [BICreatTime] [date] NOT NULL, ");
                cmdText.Append(" [BIIsPrinted] [bit] NOT NULL, ");
                cmdText.Append(" CONSTRAINT [PK_BillManage] PRIMARY KEY CLUSTERED  ");
                cmdText.Append(" ( ");
                cmdText.Append(" [BIID] ASC ");
                cmdText.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdText.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdText.ToString());

                StringBuilder cmdTextBS = new StringBuilder();
                cmdTextBS.Append(" CREATE TABLE [dbo].[BillSetInfo]( ");
                cmdTextBS.Append(" [BSIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextBS.Append(" [BSIName] [nvarchar](30) NOT NULL, ");
                cmdTextBS.Append(" [BSICompanyID] [int] NOT NULL, ");
                cmdTextBS.Append(" [BSICreaterID] [nvarchar](10) NOT NULL, ");
                cmdTextBS.Append(" [BSICreateTime] [datetime] NOT NULL, ");
                cmdTextBS.Append(" [BSIIsEnable] [tinyint] NOT NULL, ");
                cmdTextBS.Append(" CONSTRAINT [PK_BillSetInfo] PRIMARY KEY CLUSTERED  ");
                cmdTextBS.Append(" ( ");
                cmdTextBS.Append(" [BSIID] ASC ");
                cmdTextBS.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextBS.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextBS.ToString());

                StringBuilder cmdTextCI = new StringBuilder();
                cmdTextCI.Append(" CREATE TABLE [dbo].[CompanyInfo]( ");
                cmdTextCI.Append(" [CIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextCI.Append(" [CIName] [nvarchar](30) NOT NULL, ");
                cmdTextCI.Append(" [CIDescription] [nvarchar](100) NOT NULL, ");
                cmdTextCI.Append(" [CIParentID] [int] NOT NULL, ");
                cmdTextCI.Append(" [CICreaterID] [nvarchar](10) NOT NULL, ");
                cmdTextCI.Append(" [CICreateTime] [datetime] NOT NULL, ");
                cmdTextCI.Append(" [CIIsEnable] [tinyint] NOT NULL, ");
                cmdTextCI.Append(" CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED  ");
                cmdTextCI.Append(" ( ");
                cmdTextCI.Append(" [CIID] ASC ");
                cmdTextCI.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextCI.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextCI.ToString());

                StringBuilder cmdTextCD = new StringBuilder();
                cmdTextCD.Append(" CREATE TABLE [dbo].[ControlDetails]( ");
                cmdTextCD.Append("[CDID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextCD.Append("[CDCTIID] [int] NOT NULL, ");
                cmdTextCD.Append("[CDBIID] [int] NOT NULL, ");
                cmdTextCD.Append("[CDText] [nvarchar](200) NOT NULL, ");
                cmdTextCD.Append("[CDIsEnable] [bit] NOT NULL, ");
                cmdTextCD.Append("[CDControlType] [nvarchar](20) NOT NULL, ");
                cmdTextCD.Append("[CDTIID] [int] NOT NULL, ");
                cmdTextCD.Append("[CDCTName] [nvarchar](50) NULL, ");
                cmdTextCD.Append("CONSTRAINT [PK_ControlDetails] PRIMARY KEY CLUSTERED  ");
                cmdTextCD.Append("( ");
                cmdTextCD.Append("[CDID] ASC ");
                cmdTextCD.Append(")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]  ");
                cmdTextCD.Append(") ON [PRIMARY] ");
                cmdTextList.Add(cmdTextCD.ToString());

                StringBuilder cmdTextCT = new StringBuilder();
                cmdTextCT.Append(" CREATE TABLE [dbo].[ControlInfo]( ");
                cmdTextCT.Append(" [CIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextCT.Append(" [CTName] [nvarchar](50) NOT NULL, ");
                cmdTextCT.Append(" [CTITIID] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTType] [nvarchar](30) NOT NULL, ");
                cmdTextCT.Append(" [CTDefault] [nvarchar](50) NOT NULL, ");
                cmdTextCT.Append(" [CTIsBorder] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTIsTransparent] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTLeft] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTTop] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTWidth] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTHeight] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTTabKey] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTIsReadOnly] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTVisiable] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTIsMust] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTIsPrint] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTIsEnable] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTBandsTabel] [nvarchar](50) NOT NULL, ");
                cmdTextCT.Append(" [CTBandsCoumln] [nvarchar](50) NOT NULL, ");
                cmdTextCT.Append(" [CTFont] [nvarchar](100) NOT NULL, ");
                cmdTextCT.Append(" [CTFontColor] [nvarchar](20) NOT NULL, ");
                cmdTextCT.Append(" [CTBorerColor] [nvarchar](20) NOT NULL, ");
                cmdTextCT.Append(" [CTBackColor] [nvarchar](20) NOT NULL, ");
                cmdTextCT.Append(" [CTIsFlage] [bit] NOT NULL, ");
                cmdTextCT.Append(" [CTShowType] [tinyint] NOT NULL, ");
                cmdTextCT.Append(" [CTMarkType] [tinyint] NOT NULL, ");
                cmdTextCT.Append(" [CTMPShowUnit] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTMPHighUnit] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTMPLowUnit] [int] NOT NULL, ");
                cmdTextCT.Append(" [CTMPBindsID] [int] NOT NULL, ");
                cmdTextCT.Append(" CONSTRAINT [PK_ControlInfo_1] PRIMARY KEY CLUSTERED  ");
                cmdTextCT.Append(" ( ");
                cmdTextCT.Append(" [CIID] ASC ");
                cmdTextCT.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextCT.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextCT.ToString());

                StringBuilder cmdTextDSI = new StringBuilder();
                cmdTextDSI.Append(" CREATE TABLE [dbo].[DataSourceInfo]( ");
                cmdTextDSI.Append(" [DSIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextDSI.Append(" [DSITableName] [nvarchar](50) NOT NULL, ");
                cmdTextDSI.Append(" [DSIColums] [nvarchar](50) NOT NULL, ");
                cmdTextDSI.Append(" [DSICIID] [int] NOT NULL, ");
                cmdTextDSI.Append(" [DSIIsEnable] [bit] NOT NULL, ");
                cmdTextDSI.Append(" CONSTRAINT [PK_DataSourceInfo] PRIMARY KEY CLUSTERED  ");
                cmdTextDSI.Append(" ( ");
                cmdTextDSI.Append(" [DSIID] ASC ");
                cmdTextDSI.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextDSI.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextDSI.ToString());


                StringBuilder cmdTextDPI = new StringBuilder();
                cmdTextDPI.Append(" CREATE TABLE [dbo].[DepartmentInfo](  ");
                cmdTextDPI.Append(" [DIID] [int] IDENTITY(1,1) NOT NULL,  ");
                cmdTextDPI.Append(" [DIName] [nvarchar](50) NOT NULL,  ");
                cmdTextDPI.Append(" [DICIID] [int] NOT NULL,  ");
                cmdTextDPI.Append(" [DIIsEnable] [bit] NOT NULL,  ");
                cmdTextDPI.Append("  CONSTRAINT [PK_DepartmentInfo] PRIMARY KEY CLUSTERED   ");
                cmdTextDPI.Append(" (  ");
                cmdTextDPI.Append(" 	[DIID] ASC ");
                cmdTextDPI.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]  ");
                cmdTextDPI.Append(" ) ON [PRIMARY]  ");
                cmdTextList.Add(cmdTextDPI.ToString());

                StringBuilder cmdTextEI = new StringBuilder();
                cmdTextEI.Append(" CREATE TABLE [dbo].[EmployeeInfo]( ");
                cmdTextEI.Append(" [EIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextEI.Append(" [EINo] [nvarchar](10) NOT NULL, ");
                cmdTextEI.Append(" [EIName] [nvarchar](30) NOT NULL, ");
                cmdTextEI.Append(" [EIPhoto] [image] NOT NULL, ");
                cmdTextEI.Append(" [EISex] [bit] NOT NULL, ");
                cmdTextEI.Append(" [EIDepartment] [nvarchar](30) NOT NULL, ");
                cmdTextEI.Append(" [EIPosition] [nvarchar](20) NOT NULL, ");
                cmdTextEI.Append(" [EIBirthday] [date] NOT NULL, ");
                cmdTextEI.Append(" [EIEntryDate] [date] NOT NULL, ");
                cmdTextEI.Append(" [EIRemark] [nvarchar](50) NOT NULL, ");
                cmdTextEI.Append(" [EICompanyID] [int] NOT NULL, ");
                cmdTextEI.Append(" [EIIsEnable] [bit] NOT NULL, ");
                cmdTextEI.Append("  CONSTRAINT [PK_EmployeeInfo] PRIMARY KEY CLUSTERED  ");
                cmdTextEI.Append(" ( ");
                cmdTextEI.Append(" 	[EIID] ASC ");
                cmdTextEI.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextEI.Append(" ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] ");
                cmdTextList.Add(cmdTextEI.ToString());

                StringBuilder cmdTextPI = new StringBuilder();
                cmdTextPI.Append(" CREATE TABLE [dbo].[PermissionInfo]( ");
                cmdTextPI.Append(" [PIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextPI.Append(" [PIEINo] [nvarchar](10) NOT NULL, ");
                cmdTextPI.Append(" [PITemplate] [bit] NOT NULL, ");
                cmdTextPI.Append(" [PIDataSource] [bit] NOT NULL, ");
                cmdTextPI.Append(" [PIBill] [bit] NOT NULL, ");
                cmdTextPI.Append(" [PIUser] [bit] NOT NULL, ");
                cmdTextPI.Append(" [PISet] [bit] NOT NULL, ");
                cmdTextPI.Append(" [PIAdmin] [bit] NOT NULL, ");
                cmdTextPI.Append(" [PIIsEnable] [bit] NOT NULL, ");
                cmdTextPI.Append(" CONSTRAINT [PK_PermissionInfo] PRIMARY KEY CLUSTERED  ");
                cmdTextPI.Append(" ( ");
                cmdTextPI.Append(" 	[PIID] ASC ");
                cmdTextPI.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextPI.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextPI.ToString());

                StringBuilder cmdTextPOI = new StringBuilder();
                cmdTextPOI.Append("  CREATE TABLE [dbo].[PositionInfo]( ");
                cmdTextPOI.Append("  [PIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextPOI.Append("  [PIName] [nvarchar](50) NOT NULL, ");
                cmdTextPOI.Append("  [PIDIID] [int] NOT NULL, ");
                cmdTextPOI.Append("  [PIIsEnable] [bit] NOT NULL, ");
                cmdTextPOI.Append("  CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED  ");
                cmdTextPOI.Append("  ( ");
                cmdTextPOI.Append("  [PIID] ASC ");
                cmdTextPOI.Append("  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextPOI.Append("  ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextPOI.ToString());

                StringBuilder cmdTextPS = new StringBuilder();
                cmdTextPS.Append(" CREATE TABLE [dbo].[PrintSet]( ");
                cmdTextPS.Append(" [PSID] [int] NOT NULL, ");
                cmdTextPS.Append(" [PSName] [nvarchar](50) NOT NULL, ");
                cmdTextPS.Append(" [PSLeft] [int] NOT NULL, ");
                cmdTextPS.Append(" [PSRight] [int] NOT NULL, ");
                cmdTextPS.Append(" [PSIsEnable] [bit] NOT NULL, ");
                cmdTextPS.Append(" CONSTRAINT [PK_PrintSet] PRIMARY KEY CLUSTERED  ");
                cmdTextPS.Append(" ( ");
                cmdTextPS.Append(" 	[PSID] ASC ");
                cmdTextPS.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextPS.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextPS.ToString());

                StringBuilder cmdTextTI = new StringBuilder();
                cmdTextTI.Append(" CREATE TABLE [dbo].[TemplateInfo](  ");
                cmdTextTI.Append(" [TIID] [int] IDENTITY(1,1) NOT NULL,  ");
                cmdTextTI.Append(" [TIName] [nvarchar](30) NOT NULL,  ");
                cmdTextTI.Append(" [TIBackground] [image] NOT NULL,  ");
                cmdTextTI.Append(" [TIWidth] [int] NOT NULL,  ");
                cmdTextTI.Append(" [TIHeight] [int] NOT NULL,  ");
                cmdTextTI.Append(" [TITTID] [int] NOT NULL,  ");
                cmdTextTI.Append(" [TICodeLegth] [int] NOT NULL,  ");
                cmdTextTI.Append(" [TICreaterID] [nvarchar](20) NOT NULL,  ");
                cmdTextTI.Append(" [TICreateTime] [datetime] NOT NULL,  ");
                cmdTextTI.Append(" [TIIsEnable] [tinyint] NOT NULL,  ");
                cmdTextTI.Append(" [TIIsPrintBg] [tinyint] NOT NULL,  ");
                cmdTextTI.Append(" CONSTRAINT [PK_TemplateInfo] PRIMARY KEY CLUSTERED   ");
                cmdTextTI.Append(" (  ");
                cmdTextTI.Append(" [TIID] ASC  ");
                cmdTextTI.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]  ");
                cmdTextTI.Append(" ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] ");
                cmdTextList.Add(cmdTextTI.ToString());

                StringBuilder cmdTextTT = new StringBuilder();
                cmdTextTT.Append(" CREATE TABLE [dbo].[TemplateType]( ");
                cmdTextTT.Append(" [TTID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextTT.Append(" [TTName] [nvarchar](30) NOT NULL, ");
                cmdTextTT.Append(" [TTBillSetID] [int] NOT NULL, ");
                cmdTextTT.Append(" [TTCreaterID] [nvarchar](20) NOT NULL, ");
                cmdTextTT.Append(" [TTCreateTime] [datetime] NOT NULL, ");
                cmdTextTT.Append(" [TTIsEnable] [tinyint] NOT NULL, ");
                cmdTextTT.Append("  CONSTRAINT [PK_TemplateType] PRIMARY KEY CLUSTERED  ");
                cmdTextTT.Append(" (  ");
                cmdTextTT.Append(" [TTID] ASC ");
                cmdTextTT.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextTT.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextTT.ToString());

                StringBuilder cmdTextUI = new StringBuilder();
                cmdTextUI.Append(" CREATE TABLE [dbo].[UserInfo]( ");
                cmdTextUI.Append(" [UIID] [int] IDENTITY(1,1) NOT NULL, ");
                cmdTextUI.Append(" [UIEINo] [nvarchar](10) NOT NULL, ");
                cmdTextUI.Append(" [UIPassword] [nvarchar](50) NOT NULL, ");
                cmdTextUI.Append(" [UICreateTime] [datetime] NOT NULL, ");
                cmdTextUI.Append(" [UIIsEnable] [bit] NOT NULL, ");
                cmdTextUI.Append(" [UICompanyID] [int] NOT NULL, ");
                cmdTextUI.Append(" CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED  ");
                cmdTextUI.Append(" ( ");
                cmdTextUI.Append(" [UIID] ASC ");
                cmdTextUI.Append(" )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ");
                cmdTextUI.Append(" ) ON [PRIMARY] ");
                cmdTextList.Add(cmdTextUI.ToString());

                StringBuilder cmdTextPD = new StringBuilder();
                cmdTextPD.Append(" CREATE PROCEDURE  [dbo].[P_QueryBill] @TIID  nvarchar(30) AS ");
                cmdTextPD.Append("declare  @CIID int ");
                cmdTextPD.Append("declare @strSql nvarchar(4000) ");
                cmdTextPD.Append("SET @strSql = N'SELECT ' ");
                cmdTextPD.Append("DECLARE cur CURSOR for ");
                cmdTextPD.Append("    SELECT CIID FROM ControlInfo Where CTITIID = @TIID ");
                cmdTextPD.Append("OPEN cur  ");
                cmdTextPD.Append("WHILE @@ERROR = 0 ");
                cmdTextPD.Append("   BEGIN ");
                cmdTextPD.Append("     FETCH NEXT FROM cur  ");
                cmdTextPD.Append("     INTO @CIID ");
                cmdTextPD.Append("     if @@FETCH_STATUS = 0 ");
                cmdTextPD.Append("       if @strSql = 'SELECT ' ");
                cmdTextPD.Append(@"          set @strSql = @strSql+ 'MAX(CASE CDCTIID WHEN  '+cast(@CIID as nvarchar(10))+' THEN CDText ELSE NULL END) as ""'+cast(@CIID as nvarchar(10))+'""' ");
                cmdTextPD.Append("       else ");
                cmdTextPD.Append(@"          set @strSql = @strSql+ ',MAX(CASE CDCTIID WHEN  '+cast(@CIID as nvarchar(10))+' THEN CDText ELSE NULL END) as ""'+cast(@CIID as nvarchar(10))+'""' ");
                cmdTextPD.Append("    else ");
                cmdTextPD.Append("       break ");
                cmdTextPD.Append("  END ");
                cmdTextPD.Append("set @strSql = @strSql+ ' FROM ControlDetails Where CDTIID ='+@TIID+' GROUP BY CDBIID' ");
                cmdTextPD.Append("EXEC sp_executesql   @strSql  ");
                cmdTextPD.Append("CLOSE cur ");
                cmdTextPD.Append("DEALLOCATE cur ");
                cmdTextList.Add(cmdTextPD.ToString());

                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillManage_BIName]  DEFAULT ('') FOR [BIName]  ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillManage_BITIID]  DEFAULT ((1)) FOR [BITIID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_Table_1_BISender1]  DEFAULT ('') FOR [BISenderCode] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillManage_BISender]  DEFAULT ('') FOR [BISender] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_Table_1_BIReciver1]  DEFAULT ('') FOR [BIReciverCode] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillManage_BIReciver]  DEFAULT ('') FOR [BIReciver] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillManage_BIAmount]  DEFAULT ((0)) FOR [BIAmount] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillManage_BIIsEnable]  DEFAULT ((1)) FOR [BIIsEnable] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillInfo_BIPrintTime]  DEFAULT (getdate()) FOR [BICreatTime] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillInfo] ADD  CONSTRAINT [DF_BillInfo_BIIsPrinted]  DEFAULT ((1)) FOR [BIIsPrinted] ");

                cmdTextList.Add("  ALTER TABLE [dbo].[BillSetInfo] ADD  CONSTRAINT [DF_BillSetInfo_BSIName]  DEFAULT ('') FOR [BSIName] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillSetInfo] ADD  CONSTRAINT [DF_BillSetInfo_BSICompanyID]  DEFAULT ('') FOR [BSICompanyID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillSetInfo] ADD  CONSTRAINT [DF_BillSetInfo_CICreaterID]  DEFAULT ((0)) FOR [BSICreaterID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillSetInfo] ADD  CONSTRAINT [DF_BillSetInfo_CICreateTime]  DEFAULT (getdate()) FOR [BSICreateTime] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[BillSetInfo] ADD  CONSTRAINT [DF_BillSetInfo_CIIsEnable]  DEFAULT ((1)) FOR [BSIIsEnable] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF_CompanyInfo_CIDescription]  DEFAULT ('') FOR [CIDescription] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF_CompanyInfo_CIParentID]  DEFAULT ((1)) FOR [CIParentID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF_CompanyInfo_CICreaterID]  DEFAULT ((0)) FOR [CICreaterID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF_CompanyInfo_CICreateTime]  DEFAULT (getdate()) FOR [CICreateTime] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[CompanyInfo] ADD  CONSTRAINT [DF_CompanyInfo_CIIsEnable]  DEFAULT ((1)) FOR [CIIsEnable] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[ControlDetails] ADD  CONSTRAINT [DF_ControlDetails_CDCTIID]  DEFAULT ((1)) FOR [CDCTIID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlDetails] ADD  CONSTRAINT [DF_ControlDetails_CDBIID]  DEFAULT ((1)) FOR [CDBIID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlDetails] ADD  CONSTRAINT [DF_ControlDetails_CDText]  DEFAULT ('') FOR [CDText] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlDetails] ADD  CONSTRAINT [DF_ControlDetails_CDIsEnable]  DEFAULT ((1)) FOR [CDIsEnable] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlDetails] ADD  CONSTRAINT [DF_ControlDetails_CDCTName]  DEFAULT ('') FOR [CDCTName] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCName]  DEFAULT ('') FOR [CTName] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_CTITIID]  DEFAULT ((1)) FOR [CTITIID] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_CTType]  DEFAULT ('TextBox') FOR [CTType] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCDefault]  DEFAULT ('') FOR [CTDefault] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCIsBorder]  DEFAULT ((1)) FOR [CTIsBorder] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCIsTransparent]  DEFAULT ((1)) FOR [CTIsTransparent] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCLeft]  DEFAULT ((0)) FOR [CTLeft] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCTop]  DEFAULT ((0)) FOR [CTTop] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCWidth]  DEFAULT ((0)) FOR [CTWidth] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCHeight]  DEFAULT ((0)) FOR [CTHeight] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCTabKey]  DEFAULT ((1)) FOR [CTTabKey] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCIsReadOnly]  DEFAULT ((1)) FOR [CTIsReadOnly] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCVisiable]  DEFAULT ((1)) FOR [CTVisiable] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCIsMust]  DEFAULT ((1)) FOR [CTIsMust] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCIsPrint]  DEFAULT ((1)) FOR [CTIsPrint] ");
                cmdTextList.Add("  ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCIsEnable]  DEFAULT ((1)) FOR [CTIsEnable] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCBandsTabel]  DEFAULT ('') FOR [CTBandsTabel] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCBandsCoumln]  DEFAULT ('') FOR [CTBandsCoumln] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCFont]  DEFAULT ('') FOR [CTFont] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCIsFlage]  DEFAULT ((1)) FOR [CTIsFlage] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCShowType]  DEFAULT ((1)) FOR [CTShowType] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_TCMarkType]  DEFAULT ((0)) FOR [CTMarkType] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_MPShowUnit]  DEFAULT ((1)) FOR [CTMPShowUnit] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_MPHighUnit]  DEFAULT ('亿') FOR [CTMPHighUnit] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_MPLowUnit]  DEFAULT ('分') FOR [CTMPLowUnit] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[ControlInfo] ADD  CONSTRAINT [DF_ControlInfo_MPBindsID]  DEFAULT ((1)) FOR [CTMPBindsID] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[DataSourceInfo] ADD  CONSTRAINT [DF_DataSourceInfo_DSITableName]  DEFAULT ('') FOR [DSITableName] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[DataSourceInfo] ADD  CONSTRAINT [DF_DataSourceInfo_DSIColums]  DEFAULT ('') FOR [DSIColums] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[DataSourceInfo] ADD  CONSTRAINT [DF_DataSourceInfo_DSIIsEnable]  DEFAULT ((1)) FOR [DSIIsEnable] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[DepartmentInfo] ADD  CONSTRAINT [DF_DepartmentInfo_DIName]  DEFAULT ('') FOR [DIName] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[DepartmentInfo] ADD  CONSTRAINT [DF_DepartmentInfo_DICIID]  DEFAULT ((0)) FOR [DICIID]  ");
                cmdTextList.Add(" ALTER TABLE [dbo].[DepartmentInfo] ADD  CONSTRAINT [DF_DepartmentInfo_DIIsEnabel]  DEFAULT ((1)) FOR [DIIsEnable]  ");

                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EINo]  DEFAULT ('') FOR [EINo]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIName]  DEFAULT ('') FOR [EIName]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIPhoto]  DEFAULT ('') FOR [EIPhoto]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EISex]  DEFAULT ((1)) FOR [EISex]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIDepartment]  DEFAULT ('') FOR [EIDepartment]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIPosition]  DEFAULT ('') FOR [EIPosition]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIBirthday]  DEFAULT (getdate()) FOR [EIBirthday]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIEntryDate]  DEFAULT (getdate()) FOR [EIEntryDate]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIRemark]  DEFAULT ('') FOR [EIRemark]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EICompanyID]  DEFAULT ((1)) FOR [EICompanyID]");
                cmdTextList.Add(" ALTER TABLE [dbo].[EmployeeInfo] ADD  CONSTRAINT [DF_EmployeeInfo_EIIsEnable]  DEFAULT ((1)) FOR [EIIsEnable]");

                cmdTextList.Add("  ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PIEIID]  DEFAULT ((1)) FOR [PIEINo]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PITemplate]  DEFAULT ((1)) FOR [PITemplate]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PIIsEnbale]  DEFAULT ((1)) FOR [PIDataSource]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PIBill]  DEFAULT ((1)) FOR [PIBill]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PIUser]  DEFAULT ((1)) FOR [PIUser]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PISet]  DEFAULT ((1)) FOR [PISet]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PIAdmin]  DEFAULT ((0)) FOR [PIAdmin]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PermissionInfo] ADD  CONSTRAINT [DF_PermissionInfo_PIIsEnable]  DEFAULT ((1)) FOR [PIIsEnable] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[PositionInfo] ADD  CONSTRAINT [DF_Position_PIName]  DEFAULT ('') FOR [PIName]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PositionInfo] ADD  CONSTRAINT [DF_Position_PIDIID]  DEFAULT ((1)) FOR [PIDIID]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PositionInfo] ADD  CONSTRAINT [DF_Position_PIIsEnabel]  DEFAULT ((1)) FOR [PIIsEnable] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[PrintSet] ADD  CONSTRAINT [DF_PrintSet_PSName]  DEFAULT ('') FOR [PSName] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[PrintSet] ADD  CONSTRAINT [DF_PrintSet_PSLeft]  DEFAULT ((0)) FOR [PSLeft] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[PrintSet] ADD  CONSTRAINT [DF_PrintSet_PSRight]  DEFAULT ((0)) FOR [PSRight]");
                cmdTextList.Add(" ALTER TABLE [dbo].[PrintSet] ADD  CONSTRAINT [DF_PrintSet_PSIsEnable]  DEFAULT ((1)) FOR [PSIsEnable] ");

                cmdTextList.Add("  ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TIName]  DEFAULT ('') FOR [TIName] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TIBackground]  DEFAULT ('') FOR [TIBackground] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TIWidth]  DEFAULT ((0)) FOR [TIWidth] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TIHeight]  DEFAULT ((0)) FOR [TIHeight] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TITTID]  DEFAULT ((1)) FOR [TITTID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TICodeLegth]  DEFAULT ((0)) FOR [TICodeLegth] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TTCreaterID]  DEFAULT ((1)) FOR [TICreaterID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TTCreateTime]  DEFAULT (getdate()) FOR [TICreateTime] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TTIsEnable]  DEFAULT ((1)) FOR [TIIsEnable] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateInfo] ADD  CONSTRAINT [DF_TemplateInfo_TIIsPrintBg]  DEFAULT ((0)) FOR [TIIsPrintBg] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateType] ADD  CONSTRAINT [DF_TemplateType_TTName]  DEFAULT ('') FOR [TTName] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateType] ADD  CONSTRAINT [DF_TemplateType_TTBillSetID]  DEFAULT ((1)) FOR [TTBillSetID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateType] ADD  CONSTRAINT [DF_Table_1_BSICreaterID]  DEFAULT ((1)) FOR [TTCreaterID] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateType] ADD  CONSTRAINT [DF_Table_1_BSICreateTime]  DEFAULT (getdate()) FOR [TTCreateTime] ");
                cmdTextList.Add(" ALTER TABLE [dbo].[TemplateType] ADD  CONSTRAINT [DF_Table_1_BSIIsEnable]  DEFAULT ((1)) FOR [TTIsEnable] ");

                cmdTextList.Add(" ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UIEINo]  DEFAULT ('') FOR [UIEINo]  ");
                cmdTextList.Add(" ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UIPassword]  DEFAULT ((123456)) FOR [UIPassword]  ");
                cmdTextList.Add(" ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UICreateTime]  DEFAULT (getdate()) FOR [UICreateTime]  ");
                cmdTextList.Add(" ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UIIsEnable]  DEFAULT ((1)) FOR [UIIsEnable]   ");
                cmdTextList.Add(" ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UICompanyID]  DEFAULT ((0)) FOR [UICompanyID]  ");
                
                String sqlConString = "Server = " + serverIP + ";Database = " + dbName + ";User id=" + user + ";PWD=" + pwd;
                return new MySqlHelper(sqlConString).ExecDataBySqls(cmdTextList);
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        /// <summary>
        /// 创建管理员账号
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="dbName"></param>
        /// <param name="name"></param>
        /// <param name="adPwd"></param>
        /// <returns></returns>
        public bool CreatAdmin(String serverIP, String user, String pwd, String dbName,String name,String adPwd)
        {
            List<String> cmdList = new List<String>();
            StringBuilder cmdTextUI = new StringBuilder();
            cmdTextUI.AppendFormat(" insert into UserInfo ( UIEINo, UIPassword) values('{0}','{1}') ", name, adPwd);
            cmdList.Add(cmdTextUI.ToString());
            StringBuilder cmdTextEI = new StringBuilder();
            cmdTextEI.AppendFormat(" insert into EmployeeInfo ( EINo,EIName,EICompanyID) values('{0}','管理员','1') ", name);
            cmdList.Add(cmdTextEI.ToString());
            StringBuilder cmdTextPM = new StringBuilder();
            cmdTextPM.AppendFormat(" insert into PermissionInfo ( PIEINo, PIAdmin) values('{0}','1') ", name);
            cmdList.Add(cmdTextPM.ToString());
            String sqlConString = "Server = " + serverIP + ";Database = " + dbName + ";User id=" + user + ";PWD=" + pwd;
            return new MySqlHelper(sqlConString).ExecDataBySqls(cmdList);    
        }

        /// <summary>
        /// 创建公司和账套
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="dbName"></param>
        /// <param name="comName"></param>
        /// <param name="bsName"></param>
        /// <returns></returns>
        public bool CreateCompanyAndBillSet(String serverIP, String user, String pwd, String dbName, String comName, String bsName)
        {
            String sqlConString = "Server = " + serverIP + ";Database = " + dbName + ";User id=" + user + ";PWD=" + pwd;
            StringBuilder cmdTextCI = new StringBuilder();
            cmdTextCI.AppendFormat(" insert into CompanyInfo (CIName,CIParentID) values('{0}','0') ", comName);
            int cid = new MySqlHelper(sqlConString).ExecSqlReturnId(cmdTextCI.ToString());
            StringBuilder cmdTextBS = new StringBuilder();
            cmdTextBS.AppendFormat(" insert into BillSetInfo (BSIName,BSICompanyID) values('{0}','1') ", bsName);
            return new MySqlHelper(sqlConString).ExecDataBySql(cmdTextBS.ToString()) > 0 ? true : false;
        }
        
        /// <summary>
        /// 返回目标服务器所有数据库名称
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DataTable GetAllDBName(String serverIP, String user, String pwd)
        {
            try
            {
                DataTable dt = new DataTable();
                String sqlConString = "Server = " + serverIP + ";Database = master;User id=" + user + ";PWD=" + pwd;
                MySqlHelper msql = new MySqlHelper(sqlConString);
                StringBuilder sb = new StringBuilder();
                sb.Append("select name from sysdatabases");
                return msql.GetDataTable(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
