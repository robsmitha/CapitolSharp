﻿using CapitolSharp.Congress.Amendments;
using CapitolSharp.Congress.Bills;
using CapitolSharp.Congress.BoundCongressionalRecords;
using CapitolSharp.Congress.CommitteeMeetings;
using CapitolSharp.Congress.CommitteePrints;
using CapitolSharp.Congress.CommitteeReports;
using CapitolSharp.Congress.Committees;
using CapitolSharp.Congress.Congresses;
using CapitolSharp.Congress.CongressionalRecords;
using CapitolSharp.Congress.DailyCongressionalRecords;
using CapitolSharp.Congress.Hearings;
using CapitolSharp.Congress.HouseCommunications;
using CapitolSharp.Congress.HouseRequirements;
using CapitolSharp.Congress.Laws;
using CapitolSharp.Congress.Members;
using CapitolSharp.Congress.Nominations;
using CapitolSharp.Congress.SenateCommunications;
using CapitolSharp.Congress.Summaries;
using CapitolSharp.Congress.Tests.Fixtures;
using CapitolSharp.Congress.Treaties;
using Moq;

namespace CapitolSharp.Congress.Tests
{
    [Collection("Congress collection")]
    public class ApiClientTests(CapitolSharpFixture fixture) : IAsyncLifetime
    {
        public Task InitializeAsync() => Task.CompletedTask;

        [Theory]
        [InlineData(typeof(AmendmentRequest), "amendment/Amendment.json")]
        [InlineData(typeof(AmendmentListByCongressRequest), "amendment/AmendmentListByCongress.json")]
        [InlineData(typeof(AmendmentListRequest), "amendment/AmendmentList.json")]
        [InlineData(typeof(AmendmentDetailsRequest), "amendment/AmendmentDetails.json")]
        [InlineData(typeof(AmendmentActionsRequest), "amendment/AmendmentActions.json")]
        [InlineData(typeof(AmendmentCosponsorsRequest), "amendment/AmendmentCosponsors.json")]
        [InlineData(typeof(AmendmentAmendmentsRequest), "amendment/AmendmentAmendments.json")]
        [InlineData(typeof(AmendmentTextRequest), "amendment/AmendmentText.json")]
        [InlineData(typeof(BillListAllRequest), "bill/bill_list_all.json")]
        [InlineData(typeof(BillListByCongressRequest), "bill/bill_list_by_congress.json")]
        [InlineData(typeof(BillListByTypeRequest), "bill/bill_list_by_type.json")]
        [InlineData(typeof(BillDetailsRequest), "bill/bill_details.json")]
        [InlineData(typeof(BillActionsRequest), "bill/bill_actions.json")]
        [InlineData(typeof(BillAmendmentsRequest), "bill/bill_amendments.json")]
        [InlineData(typeof(BillCommitteesRequest), "bill/bill_committees.json")]
        [InlineData(typeof(BillCosponsorsRequest), "bill/bill_cosponsors.json")]
        [InlineData(typeof(BillRelatedbillsRequest), "bill/bill_relatedbills.json")]
        [InlineData(typeof(BillSubjectsRequest), "bill/bill_subjects.json")]
        [InlineData(typeof(BillSummariesRequest), "bill/bill_summaries.json")]
        [InlineData(typeof(BillTextRequest), "bill/bill_text.json")]
        [InlineData(typeof(BillTitlesRequest), "bill/bill_titles.json")]
        [InlineData(typeof(BillSummariesAllRequest), "summaries/bill_summaries_all.json")]
        [InlineData(typeof(BillSummariesByCongressRequest), "summaries/bill_summaries_by_congress.json")]
        [InlineData(typeof(BillSummariesByTypeRequest), "summaries/bill_summaries_by_type.json")]
        [InlineData(typeof(LawListByCongressRequest), "law/law_list_by_congress.json")]
        [InlineData(typeof(LawListByCongressAndLawTypeRequest), "law/law_list_by_congress_and_lawType.json")]
        [InlineData(typeof(LawListByCongressLawTypeAndLawNumberRequest), "law/law_list_by_congress_lawType_and_lawNumber.json")]
        [InlineData(typeof(Congresses.CongressListRequest), "congress/congress_list.json")]
        [InlineData(typeof(CongressDetailsRequest), "congress/congress_details.json")]
        [InlineData(typeof(CongressCurrentListRequest), "congress/congress_current_list.json")]
        [InlineData(typeof(MemberListRequest), "member/member_list.json")]
        [InlineData(typeof(MemberDetailsRequest), "member/member_details.json")]
        [InlineData(typeof(SponsorshipListRequest), "member/sponsorship_list.json")]
        [InlineData(typeof(CosponsorshipListRequest), "member/cosponsorship_list.json")]
        [InlineData(typeof(Members.CongressListRequest), "member/congress_list.json")]
        [InlineData(typeof(MemberListByStateRequest), "member/member_list_by_state.json")]
        [InlineData(typeof(MemberListByStateAndDistrictRequest), "member/member_list_by_state_and_district.json")]
        [InlineData(typeof(MemberListByCongressStateDistrictRequest), "member/member_list_by_congress_state_district.json")]
        [InlineData(typeof(CommitteeListRequest), "committee/committee_list.json")]
        [InlineData(typeof(CommitteeListByChamberRequest), "committee/committee_list_by_chamber.json")]
        [InlineData(typeof(CommitteeListByCongressRequest), "committee/committee_list_by_congress.json")]
        [InlineData(typeof(CommitteeListByCongressChamberRequest), "committee/committee_list_by_congress_chamber.json")]
        [InlineData(typeof(CommitteeDetailsRequest), "committee/committee_details.json")]
        [InlineData(typeof(CommitteeBillsListRequest), "committee/committee_bills_list.json")]
        [InlineData(typeof(CommitteeReportsByCommitteeRequest), "committee/committee_reports_by_committee.json")]
        [InlineData(typeof(NominationByCommitteeRequest), "committee/nomination_by_committee.json")]
        [InlineData(typeof(HouseCommunicationsByCommitteeRequest), "committee/house_communications_by_committee.json")]
        [InlineData(typeof(SenateCommunicationsByCommitteeRequest), "committee/senate_communications_by_committee.json")]
        [InlineData(typeof(CommitteeReportsRequest), "committee-report/committee_reports.json")]
        [InlineData(typeof(CommitteeReportsByCongressRequest), "committee-report/committee_reports_by_congress.json")]
        [InlineData(typeof(CommitteeReportsByCongressRptTypeRequest), "committee-report/committee_reports_by_congress_rpt_type.json")]
        [InlineData(typeof(CommitteeReportDetailsRequest), "committee-report/committee_report_details.json")]
        [InlineData(typeof(CommitteeReportIdTextRequest), "committee-report/committee_report_id_text.json")]
        [InlineData(typeof(CommitteePrintListRequest), "committee-print/committee_print_list.json")]
        [InlineData(typeof(CommitteePrintsByCongressRequest), "committee-print/committee_prints_by_congress.json")]
        [InlineData(typeof(CommitteePrintsByCongressChamberRequest), "committee-print/committee_prints_by_congress_chamber.json")]
        [InlineData(typeof(CommitteePrintDetailRequest), "committee-print/committee_print_detail.json")]
        [InlineData(typeof(CommitteePrintTextRequest), "committee-print/committee_print_text.json")]
        [InlineData(typeof(CommitteeMeetingListRequest), "committee-meeting/committee_meeting_list.json")]
        [InlineData(typeof(CommitteeMeetingCongressRequest), "committee-meeting/committee_meeting_congress.json")]
        [InlineData(typeof(CommitteeMeetingCongressChamberRequest), "committee-meeting/committee_meeting_congress_chamber.json")]
        [InlineData(typeof(CommitteeMeetingDetailRequest), "committee-meeting/committee_meeting_detail.json")]
        [InlineData(typeof(HearingListRequest), "hearing/hearing_list.json")]
        [InlineData(typeof(HearingListByCongressRequest), "hearing/hearing_list_by_congress.json")]
        [InlineData(typeof(HearingListByCongressChamberRequest), "hearing/hearing_list_by_congress_chamber.json")]
        [InlineData(typeof(HearingDetailRequest), "hearing/hearing_detail.json")]
        [InlineData(typeof(CongressionalRecordListRequest), "congressional-record/congressional_record_list.json")]
        [InlineData(typeof(DailyCongressionalRecordListRequest), "daily-congressional-record/daily_congressional_record_list.json")]
        [InlineData(typeof(DailyCongressionalRecordListByVolumeRequest), "daily-congressional-record/daily_congressional_record_list_by_volume.json")]
        [InlineData(typeof(DailyCongressionalRecordListByVolumeAndIssueRequest), "daily-congressional-record/daily_congressional_record_list_by_volume_and_issue.json")]
        [InlineData(typeof(DailyCongressionalRecordListByArticleRequest), "daily-congressional-record/daily_congressional_record_list_by_article.json")]
        [InlineData(typeof(BoundCongressionalRecordListRequest), "bound-congressional-record/bound_congressional_record_list.json")]
        [InlineData(typeof(BoundCongressionalRecordListByYearRequest), "bound-congressional-record/bound_congressional_record_list_by_year.json")]
        [InlineData(typeof(BoundCongressionalRecordListByYearAndMonthRequest), "bound-congressional-record/bound_congressional_record_list_by_year_and_month.json")]
        [InlineData(typeof(BoundCongressionalRecordListByYearAndMonthAndDayRequest), "bound-congressional-record/bound_congressional_record_list_by_year_and_month_and_day.json")]
        [InlineData(typeof(HouseCommunicationRequest), "house-communication/house_communication.json")]
        [InlineData(typeof(HouseCommunicationCongressRequest), "house-communication/house_communication_congress.json")]
        [InlineData(typeof(HouseCommunicationListRequest), "house-communication/house_communication_list.json")]
        [InlineData(typeof(HouseCommunicationDetailRequest), "house-communication/house_communication_detail.json")]
        [InlineData(typeof(HouseRequirementRequest), "house-requirement/house_requirement.json")]
        [InlineData(typeof(HouseRequirementDetailRequest), "house-requirement/house_requirement_detail.json")]
        [InlineData(typeof(HouseRequirementCommunicationListRequest), "house-requirement/house_requirement_communication_list.json")]
        [InlineData(typeof(SenateCommunicationRequest), "senate-communication/senate_communication.json")]
        [InlineData(typeof(SenateCommunicationCongressRequest), "senate-communication/senate_communication_congress.json")]
        [InlineData(typeof(SenateCommunicationListRequest), "senate-communication/senate_communication_list.json")]
        [InlineData(typeof(SenateCommunicationDetailRequest), "senate-communication/senate_communication_detail.json")]
        [InlineData(typeof(NominationListRequest), "nomination/nomination_list.json")]
        [InlineData(typeof(NominationListByCongressRequest), "nomination/nomination_list_by_congress.json")]
        [InlineData(typeof(NominationDetailRequest), "nomination/nomination_detail.json")]
        [InlineData(typeof(NomineesRequest), "nomination/nominees.json")]
        [InlineData(typeof(NominationActionsRequest), "nomination/nomination_actions.json")]
        [InlineData(typeof(NominationCommitteesRequest), "nomination/nomination_committees.json")]
        [InlineData(typeof(NominationHearingsRequest), "nomination/nomination_hearings.json")]
        [InlineData(typeof(TreatyListRequest), "treaty/treaty_list.json")]
        [InlineData(typeof(TreatyListByCongressRequest), "treaty/treaty_list_by_congress.json")]
        [InlineData(typeof(TreatyDetailRequest), "treaty/treaty_detail.json")]
        [InlineData(typeof(TreatyDetailsRequest), "treaty/treaty_details.json")]
        [InlineData(typeof(TreatyActionRequest), "treaty/treaty_action.json")]
        [InlineData(typeof(TreatyActionsRequest), "treaty/treaty_actions.json")]
        [InlineData(typeof(TreatyCommitteeRequest), "treaty/treaty_committee.json")]
        public async Task ApiClient_SendRequest(Type requestType, string resourceName)
        {
            dynamic request = Activator.CreateInstance(requestType);

            await fixture.MockHttpResponseMessage(request, resourceName);

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.NotNull(response);
        }

        public Task DisposeAsync()
        {
            fixture.MockHttpHandler.Reset();
            return Task.CompletedTask;
        }
    }
}
