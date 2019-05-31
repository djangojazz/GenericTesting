using System;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Xsl;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GenericTesting
{

    class Program
    {
        public class Part
        {
            public int Id { get; set; }
            public string Val { get; set; }
            public DateTime DateTimeUTDC { get; set; }

            public Part() { }

            public Part(int id, string val, DateTime pstDate)
            {
                Id = id;
                Val = val;
                DateTimeUTDC = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(pstDate, DateTimeKind.Unspecified), TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
            }
            
            public override string ToString() => $"{Id} {Val} {DateTimeUTDC}";
            public override bool Equals(object obj) => (obj as Part).Id == Id && (obj as Part).Val == Val;
            public override int GetHashCode() => $"{Id} {Val}".GetHashCode();
        }
        
        private static string ReturnDesc(int i)
        {
            var array = "abcdefghijklmnopqrstuvwxyz".ToArray();
            var sb = new StringBuilder();
            
            if (i >= 26)
            {
               sb.Append(array[(i / 26) -1]);
               i -= (i / 26) * 26;
            }
            
            sb.Append(array[i]);

            return sb.ToString();
        }

        public class Hold
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static (int Id, string Name) ReturnNamedTuple(int id, string name) => (id, name);
        public static List<(int Id, string Name)> ReturnNamedTuplesFromHolder(List<Hold> holds) => holds.Select(x => (x.Id, x.Name)).ToList();

        public static void DoSomethingWithNamedTuplesInput(List<(int id, string name)> inputs) => inputs.ForEach(x => Console.WriteLine($"Doing work with {x.id} for {x.name}"));

        private static List<(int id, string name)> DeDeduper(List<(int id, string name)> list)
        {
            list.GroupBy(x => x.name).ToDictionary(x => x.Key, x => x.Count()).OrderByDescending(x => x.Value).Where(x => x.Value >= 2).ToList()
           .ForEach(x =>
           {
               Console.WriteLine($"duplicate of {x} to remove.");
               list.Remove(list.Last(y => y.name == x.Key));
           });

           return list;
        }

        
        static void Main(String[] args)
        {
            var start = "https://localhost/";
            var start2 = "http://localhost/admin/";

            var d = new Dictionary<string, string>
            {
                {"CourseEnrollmentTotalsReport", "https://localhost/admin/university/reporting/ClassEnrollmentTotals.aspx"},
                //{"CoursePaymentReport", "https://localhost/admin/university/reporting/CoursePayment.aspx"},
                //{"ScheduleResources", "https://localhost/admin/ResourceManagement/"},
                //{"BadgeManagement", "https://localhost/admin/Badge"},
                //{"AggregatedQuizResults", "http://localhost/admin/university/reporting/AggregatedTestResults.aspx"},
                //{"GradeBook", "http://localhost/admin/university/reporting/GradeBookUniversityList.aspx"},
                //{"CompletedCourseHoursReport", "http://localhost/admin/university/reporting/CourseHoursByGroup.aspx"},
                //{"mLiveViewershipReport", "http://localhost/admin/university/reporting/mLiveViewership.aspx"},
                //{"UserBbReport", "http://localhost/admin/university/reporting/BlueBucksByGroup_PLNEW.aspx"},
                //{"UniBbReport", "http://localhost/admin/university/reporting/BlueBucksUniversity.aspx"},
                //{"PromoHistoryReport", "http://localhost/admin/university/reporting/promoHistory.aspx"},
                //{"Transcript", "http://localhost/admin/university/reporting/UniversityList.aspx"},
                //{"TrainingTrackProgress", "http://localhost/admin/university/reporting/TrainingTrackProgress.aspx"},
                //{"NewUsersReport", "http://localhost/admin/statistics/NewUsers.aspx"},
                //{"BadgeReport", "http://localhost/admin/university/reporting/BadgeReport.aspx"},
                //{"ScheduledCoursesReport", "http://localhost/admin/University/Reporting/ScheduledCoursesReport"},
                //{"BtManagementIndex", "http://localhost/admin/BlueVoltManagement/default.aspx"},
                //{"AdminClientBluetechManagement", "http://localhost/admin/BlueVoltManagement/home"},
                //{"AccountingReports", "http://localhost/admin/accountmanagement/AccountingReports.aspx"},
                //{"AccountingReports_PL", "http://localhost/admin/accountmanagement/AccountingReports_PL.aspx"},
                //{"OnlineTransactionReport", "http://localhost/admin/accountmanagement/OnlineTransactionReport.aspx"},
                //{"OnlineTransactionReport_PLNEW", "http://localhost/admin/accountmanagement/OnlineTransactionReport_PLNEW.aspx"},
                //{"AwardBbManually", "http://localhost/admin/accountmanagement/bluebucks/default.aspx"},
                //{"UserAdminViewer", "http://localhost/admin/group/UserAdminView.aspx"},
                //{"StudentEmail", "https://localhost/admin/university/reporting/CourseEmailer.aspx?CourseInstanceID="},
                //{"HistoricalRecord", "https://localhost/admin/university/CourseManagement/HistoricImport/HistoricalCoursesImport.aspx"},
                {"UploadCourseFiles", "https://localhost/admin/university/UploadCourses"},
                //{"QuestionBank", "https://localhost/admin/university/CourseManagement/QuestionBankEditor.aspx"},
                //{"ScheduledReportsList", "https://localhost/admin/university/Reporting/ScheduledReportsList"},
                //{"MyReportList", "https://localhost/admin/university/Reporting/MyReportList"},
                //{"UploadUsers", "http://localhost/admin/group/uploadusers/uploaduser.aspx"},
                //{"EditGroups", "http://localhost/admin/group/Groups.aspx"},
                //{"EditGroupRoles", "http://localhost/admin/group/GroupMembers.aspx"},
                //{"EditGroupLevelBlueBucks", "http://localhost/admin/group/GroupLevelBlueBucks.aspx"},
                //{"EditUniRoles", "http://localhost/admin/group/UniversityRoleAssignment.aspx"},
                //{"EditCourseRoles", "http://localhost/admin/group/ClassRolesAssignment.aspx"},
                //{"AutoEnrollmentView", "http://localhost/admin/university/CourseManagement/AutoEnrollmentView.aspx"},
                //{"GroupHierarchyReport", "http://localhost/admin/university/reporting/GroupHierarchyReport.aspx"},
                //{"PortalBlueBucksRedemptions", "http://localhost/admin/university/reporting/PortalBlueBucksRedemptions.aspx"},
                //{"UniversityUserInvitations", "http://localhost/admin/group/UniversityUserInvitations.aspx"},
                //{"SignUpWhitelist", "http://localhost/admin/university/SignUpWhitelistEdit.aspx"},
                //{"CourseAgeReport", "http://localhost/admin/University/Reporting/CourseAgeReport"},
                //{"CourseSeatTimeReport", "http://localhost/admin/university/reporting/CourseSeatTimeReport.aspx"},
                //{"CoursePromotions", "http://localhost/admin/University/CourseManagement/coursePromotions.aspx"},
                //{"UniversityLibaraySettings", "http://localhost/admin/university/CourseManagement/UniversityLibaraySettings.aspx"},
                //{"RolesReport", "http://localhost/admin/group/RolesReport.aspx"},
                //{"EditCourses", "http://localhost/admin/university/CourseManagement/Editor.aspx"},
                //{"CoursesAddEdit", "https://localhost/admin/university/CourseList.aspx?Reset=True"},
                //{"EditCategories", "http://localhost/admin/university/CourseManagement/CategoryAdminView.aspx"},
                //{"CourseFamilyView", "http://localhost/admin/university/CourseManagement/CourseFamilyView.aspx"},
                //{"CourseLibrary", "https://localhost/admin/university/CourseManagement/CourseLibrary.aspx"},
                //{"SharedCourseDashboard", "http://localhost/admin/university/CourseManagement/SharedCourseDashboard.aspx"},
                //{"ShareCourseAcrossUniversities", "http://localhost/admin/university/CourseManagement/ShareCourseAcrossUniversities.aspx"},
                //{"CourseSchedules", "http://localhost/admin/university/CourseManagement/CourseSchedules"},
                //{"InvoicingReport", "http://localhost/admin/accountmanagement/InvoicingReport.aspx"},
                //{"BBSummaryAgingReport", "http://localhost/admin/University/Reporting/BBSummaryAgingReport"},
                //{"BBDetailAgingReport", "http://localhost/admin/University/Reporting/BBDetailAgingReport"},
                //{"CourseCompletionBBReport", "http://localhost/admin/University/Reporting/CourseCompletionBBReport"},
                //{"EditTrainingTracks", "http://localhost/Administration/home.aspx"},
                //{"ExternalCourseConsumerCourseList", "http://localhost/admin/ExternalCourseConsumer"},
                //{"ExternalUserManagement", "http://localhost/admin/ExternalCourseConsumer/UserManagement"},
                //{"ExternalCompanySettings", "http://localhost/admin/ExternalCourseConsumer/CompanySettings"},
                //{"AllowRetakes", "http://localhost/admin/university/StudentManagement/UniversityList.aspx"},
                //{"GradeEssay", "http://localhost/admin/university/StudentManagement/GradeEssayBrowse.aspx"},
                //{"ApproveActivity", "http://localhost/admin/university/StudentManagement/ApproveActivity.aspx"},
                //{"PendingEnrollments", "http://localhost/admin/enrollment/listPendingEnrollments"},
                //{"Announcements", "https://localhost/admin/university/StudentManagement/AnnouncementList.aspx"},
                //{"EmailManagement", "https://localhost/admin/university/reporting/EmailBounceBlocklist.aspx"},
                //{"TrainingCalendar", "http://localhost/admin/university/CourseManagement/TrainingCalendar/"},
                //{"ManualPass", "http://localhost/admin/university/StudentManagement/OfflineUniversityList.aspx"},
                //{"TrackOfflineCourses", "http://localhost/admin/university/StudentManagement/OfflineCourseTracking.aspx"},
                //{"CourseListEnrollment", "http://localhost/admin/university/StudentManagement/CourseEnrollmentManagement.aspx"},
                //{"CourseEnrollmentType", "http://localhost/admin/university/StudentManagement/CourseEnrollmentType.aspx"},
                //{"ReverseCoursePurchase", "http://localhost/admin/university/StudentManagement/ReverseCoursePurchase.aspx"},
                //{"ReferralsEarnings", "http://localhost/admin/university/reporting/UniversityReferralEarnings.aspx"},
                //{"UniSettingsView", "http://localhost/admin/university/UniversitySettingsView.aspx"},
                //{"UniSettingsMessages", "http://localhost/admin/university/UniversityMessages.aspx"},
                //{"UniSettingsProperties", "http://localhost/admin/university/UniversitySettingsProperties.aspx"},
                //{"UniSettingsBTAdmin", "http://localhost/admin/university/UniversitySettingsBTAdminView.aspx"},
                //{"ProfileFields", "http://localhost/admin/university/UniversitySettings/ProfileFields"},
                //{"UniCertificateUpload", "http://localhost/admin/university/UniversityCertificateUpload.aspx"},
                //{"PromoViewer", "https://localhost/admin/university/PromoViewer.aspx"},
                //{"UniDash", "http://localhost/admin/university/Dashboard.aspx"},
                //{"CourseHierarchyReport", "http://localhost/admin/university/Reporting/CourseHierarchyReport.aspx"},
                //{"AuditLog", "http://localhost/admin/university/Reporting/AuditLog.aspx"},
                //{"FileDownloadHistory", "http://localhost/admin/university/reporting/FileDownloadHistory.aspx"},
                //{"OSMarketplace", "http://localhost/admin/university/courseManagement/OSMarketplace.aspx"},
                //{"GroupCourseEditorWhiteList", "http://localhost/admin/group/GroupCourseEditorPermissions"}
            };

            //var startPoint = "admin/";
            //var startLen = startPoint.Length;

            //var val1 = d["CourseEnrollmentTotalsReport"];
            //var val2 = d["CoursePaymentReport"];

            //var var1 = val1.Substring(val1.IndexOf(startPoint) + startLen, val1.Length - (val1.IndexOf(startPoint) + startLen) );
            //var var2 = val2.Substring(val2.IndexOf(startPoint) + startLen, d["CoursePaymentReport"].Length - (val2.IndexOf(startPoint) + startLen));
            //Console.WriteLine(var1);
            //Console.WriteLine(var2);

            var node = d.GetNodesFromDictionary(new RecursiveTesting.OptionsForHeirarchy(reseatRootToName: string.Empty));

            var json = RecursiveTesting.CreateRecursiveJsonFromNode(node);

            Console.WriteLine(json);

            Console.ReadLine();
        }

        

    }
}
