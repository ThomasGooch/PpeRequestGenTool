using System;
using System.Linq;

namespace PpeRequestGenTool.Data.Model
{
    public class NCPDP
    {
        public string BINNumber { get; private set; }
        public string VersionReleaseNumber { get; private set; }
        public string TransactionCode { get; private set; }
        public string ProcessorControlNumber { get; private set; }
        public string TransactionCount { get; private set; }
        public string ServiceProviderIDQualifier { get; private set; }
        public string ServiceProviderID { get; private set; }
        public string DateofService { get; private set; }
        public string SoftwareVendor_CertificationID { get; private set; }
        public string SegmentIdentification { get; private set; }
        public string SEGMENTIDENTIFICATION { get; private set; }
        public string CardholderID { get; private set; }
        public string CardholderFirstName { get; private set; }
        public string CardholderLastName { get; private set; }
        public string HomePlan { get; private set; }
        public string PlanID { get; private set; }
        public string EligibilityClarificationCode { get; private set; }
        public string GroupID { get; private set; }
        public string PersonCode { get; private set; }
        public string PatientRelationshipCode { get; private set; }
        public string OtherPayerBINNumber { get; private set; }
        public string OtherPayerProcessorControlNumber { get; private set; }
        public string OtherPayerCardholderID { get; private set; }
        public string OtherPayerGroupID { get; private set; }
        public string MedigapID { get; private set; }
        public string MedicaidIndicator { get; private set; }
        public string ProviderAcceptAssignmentIndicator { get; private set; }
        public string CMSPartDDefinedQualifiedFacility { get; private set; }
        public string MedicaidIDNumber { get; private set; }
        public string MedicaidAgencyNumber { get; private set; }
        public string PatientIDQualifier { get; private set; }
        public string PatientID { get; private set; }
        public string DateofBirth { get; private set; }
        public string PatientGenderCode { get; private set; }
        public string PatientFirstName { get; private set; }
        public string PatientLastName { get; private set; }
        public string PatientStreetAddress { get; private set; }
        public string PatientCity { get; private set; }
        public string PatientStateorProvince { get; private set; }
        public string PatientZip_PostalCode { get; private set; }
        public string PatientPhonenumber { get; private set; }
        public string PlaceofService { get; private set; }
        public string EmployerID { get; private set; }
        public string Smoker_Non_smokerCode { get; private set; }
        public string PregnancyIndicator { get; private set; }
        public string PatientE_MailAddress { get; private set; }
        public string PatientResidence { get; private set; }
        public string ProviderIDQualifier { get; private set; }
        public string ProviderID { get; private set; }
        public string Prescription_ServiceReferenceNumberQualifier { get; private set; }
        public string Prescription_ServiceReferenceNumber { get; private set; }
        public string Product_ServiceIDQualifier { get; private set; }
        public string Product_ServiceID { get; private set; }
        public string AssociatedPrescription_ServiceDate { get; private set; }
        public string AssociatedPrescription_ServiceReferenceNumber { get; private set; }
        public string ProcedureModifierCodeCount { get; private set; }
        public string ProcedureModifierCode { get; private set; }
        public string QuantityDispensed { get; private set; }
        public string FillNumber { get; private set; }
        public string DaysSupply { get; private set; }
        public string CompoundCode { get; private set; }
        public string DispenseasWritten_ProductSelectionCode { get; private set; }
        public string DatePrescriptionWritten { get; private set; }
        public string NumberofRefillsAuthorized { get; private set; }
        public string PrescriptionOriginCode { get; private set; }
        public string SubmissionClarificationCodeCount { get; private set; }
        public string SubmissionClarificationCode { get; private set; }
        public string QuantityPrescribed { get; private set; }
        public string OtherCoverageCode { get; private set; }
        public string SpecialPackagingIndicator { get; private set; }
        public string OriginallyPrescribedProduct_ServiceIDQualifier { get; private set; }
        public string OriginallyPrescribedProduct_ServiceCode { get; private set; }
        public string OriginallyPrescribedQuantity { get; private set; }
        public string AlternateID { get; private set; }
        public string ScheduledPrescriptionIDNumber { get; private set; }
        public string UnitofMeasure { get; private set; }
        public string LevelofService { get; private set; }
        public string PriorAuthorizationTypeCode { get; private set; }
        public string PriorAuthorizationNumberSubmitted { get; private set; }
        public string IntermediaryAuthorizationTypeID { get; private set; }
        public string IntermediaryAuthorizationID { get; private set; }
        public string DispensingStatus { get; private set; }
        public string QuantityIntendedtobeDispensed { get; private set; }
        public string DelayReasonCode { get; private set; }
        public string DaysSupplyIntendedtobeDispensed { get; private set; }
        public string TransactionReferenceNumber { get; private set; }
        public string PatientAssignmentIndicator { get; private set; }
        public string RouteofAdministration { get; private set; }
        public string CompoundType { get; private set; }
        public string MedicaidSubrogationInternalControlNumber_TransactionControlNumber { get; private set; }
        public string PharmacyServiceType { get; private set; }
        public string PrescriberIDQualifier { get; private set; }
        public string PrescriberID { get; private set; }
        public string PrescriberLastName { get; private set; }
        public string PrescriberPhoneNumber { get; private set; }
        public string PrimaryCareProviderIDQualifier { get; private set; }
        public string PrimaryCareProviderID { get; private set; }
        public string PrimaryCareProviderLastName { get; private set; }
        public string PrescriberFirstName { get; private set; }
        public string PrescriberStreetAddress { get; private set; }
        public string PrescriberCityAddress { get; private set; }
        public string PrescriberState_ProvinceAddress { get; private set; }
        public string PrescriberZIP_PostalZone { get; private set; }
        public string OtherPayerCoverageType { get; private set; }
        public string CoordinationofBenefits_OtherPaymentsCount { get; private set; }
        public string OtherPayerIDQualifier { get; private set; }
        public string OtherPayerID { get; private set; }
        public string OtherPayerDate { get; private set; }
        public string InternalControlNumber { get; private set; }
        public string OtherPayerAmountPaidCount { get; private set; }
        public string OtherPayerAmountPaidQualifier { get; private set; }
        public string OtherPayerAmountPaid { get; private set; }
        public string OtherPayerRejectCount { get; private set; }
        public string OtherPayerRejectCode { get; private set; }
        public string PatientResponsibilityAmountCount { get; private set; }
        public string PatientResponsibilityAmountQualifier { get; private set; }
        public string PatientResponsibilityAmount { get; private set; }
        public string BenefitStageCount { get; private set; }
        public string BenefitStageQualifier { get; private set; }
        public string BenefitStageAmount { get; private set; }
        public string DateofInjury { get; private set; }
        public string EmployerName { get; private set; }
        public string EmployerStreetAddress { get; private set; }
        public string EmployerCityAddress { get; private set; }
        public string ProvinceAddress { get; private set; }
        public string PostalCode { get; private set; }
        public string EmployerPhoneNumber { get; private set; }
        public string EmployerContactName { get; private set; }
        public string CarrierID { get; private set; }
        public string Claim_ReferenceID { get; private set; }
        public string BillingEntityTypeIndicator { get; private set; }
        public string PayToQualifier { get; private set; }
        public string PayToID { get; private set; }
        public string PayToName { get; private set; }
        public string PayToStreetAddress { get; private set; }
        public string PayToCityAddress { get; private set; }
        public string PostalZone { get; private set; }
        public string GenericEquivalentProductIDQualifier { get; private set; }
        public string GenericEquivalentProductID { get; private set; }
        public string DUR_PPSCodeCounter { get; private set; }
        public string ReasonforServiceCode { get; private set; }
        public string ProfessionalServiceCode { get; private set; }
        public string ResultofServiceCode { get; private set; }
        public string DUR_PPSLevelofEffort { get; private set; }
        public string DURCo_AgentIDQualifier { get; private set; }
        public string DURCo_AgentID { get; private set; }
        public string IngredientCostSubmitted { get; private set; }
        public string DispensingFeeSubmitted { get; private set; }
        public string ProfessionalServiceFeeSubmitted { get; private set; }
        public string PatientPaidAmountSubmitted { get; private set; }
        public string IncentiveAmountSubmitted { get; private set; }
        public string OtherAmountClaimedSubmittedCount { get; private set; }
        public string OtherAmountClaimedSubmittedQualifier { get; private set; }
        public string OtherAmountClaimedSubmitted { get; private set; }
        public string FlatSalesTaxAmountSubmitted { get; private set; }
        public string PercentageSalesTaxAmountSubmitted { get; private set; }
        public string PercentageSalesTaxRateSubmitted { get; private set; }
        public string PercentageSalesTaxBasisSubmitted { get; private set; }
        public string UsualandCustomaryCharge { get; private set; }
        public string GrossAmountDue { get; private set; }
        public string BasisofCostDetermination { get; private set; }
        public string MedicaidPaidAmount { get; private set; }
        public string CouponType { get; private set; }
        public string CouponNumber { get; private set; }
        public string CouponValueAmount { get; private set; }
        public string CompoundDosageFormDescriptionCode { get; private set; }
        public string CompoundDispensingUnitFormIndicator { get; private set; }
        public string CompoundIngredientComponentCount { get; private set; }
        public string CompoundProductIDQualifier { get; private set; }
        public string CompoundProductID { get; private set; }
        public string CompoundIngredientQuantity { get; private set; }
        public string CompoundIngredientDrugCost { get; private set; }
        public string CompoundIngredientBasisofCostDetermination { get; private set; }
        public string CompoundIngredientModifierCodeCount { get; private set; }
        public string CompoundIngredientModifierCode { get; private set; }
        public string RequestType { get; private set; }
        public string RequestPeriodDate_Begin { get; private set; }
        public string RequestPeriodDate_End { get; private set; }
        public string BasisofRequest { get; private set; }
        public string AuthorizedRepresentativeFirstName { get; private set; }
        public string AuthorizedRep_LastName { get; private set; }
        public string AuthorizedRep_StreetAddress { get; private set; }
        public string AuthorizedRep_City { get; private set; }
        public string AuthorizedRep_State_Province { get; private set; }
        public string AuthorizedRep_Zip_PostalCode { get; private set; }
        public string PriorAuthorizationNumber_Assigned { get; private set; }
        public string AuthorizationNumber { get; private set; }
        public string PriorAuthorizationSupportingDocumentation { get; private set; }
        public string DiagnosisCodeCount { get; private set; }
        public string DiagnosisCodeQualifier { get; private set; }
        public string DiagnosisCode { get; private set; }
        public string ClinicalInformationCounter { get; private set; }
        public string MeasurementDate { get; private set; }
        public string MeasurementTime { get; private set; }
        public string MeasurementDimension { get; private set; }
        public string MeasurementUnit { get; private set; }
        public string MeasurementValue { get; private set; }
        public string AdditionalDocumentationTypeID { get; private set; }
        public string RequestPeriodBeginDate { get; private set; }
        public string RequestPeriodRecert_RevisedDate { get; private set; }
        public string RequestStatus { get; private set; }
        public string LengthOfNeedQualifier { get; private set; }
        public string LengthOfNeed { get; private set; }
        public string SupplierDateSigned { get; private set; }
        public string SupportingDocumentation { get; private set; }
        public string LetterCount { get; private set; }
        public string Letter { get; private set; }
        public string QuestionPercentResponse { get; private set; }
        public string QuestionDateResponse { get; private set; }
        public string QuestionDollarAmountResponse { get; private set; }
        public string QuestionNumericResponse { get; private set; }
        public string QuestionAlphanumericResponse { get; private set; }
        public string FacilityID { get; private set; }
        public string FacilityName { get; private set; }
        public string FacilityStreetAddress { get; private set; }
        public string FacilityCityAddress { get; private set; }
        public string NarrativeMessage { get; private set; }
        public string PMC_ADDITIONAL_MESSAGES { get; private set; }
        public string PMC_PATIENT_ID_PMC_RESIDENT_ID { get; private set; }
        public string PMC_PATIENT_ID_NURSING_HOME_RESIDENT_NUMBER { get; private set; }
        public string PMC_PATIENT_ID_ALTERNATE_RESIDENT_ID { get; private set; }
        public string PMC_PATIENT_ID_SOCIAL_SECURITY_NUM { get; private set; }
        public string PMC_PATIENT_ID_MEDICARE_NUM { get; private set; }
        public string PMC_PATIENT_ID_MEDICAID_NUM { get; private set; }
        public string PMC_PATIENT_ID_POLICY_HOLDER_NUM { get; private set; }
        public string PMC_PATIENT_ID_POLICY_NUM { get; private set; }
        public string APOLLO_CUSTOM_JSON_FIELDS { get; private set; }
        public string APOLLO_RESPONSE_SOURCE_FLAG { get; private set; }
        public string APOLLO_REASONCODE { get; private set; }
        public string APOLLO_MESSAGE { get; private set; }
        public string APOLLO_PBH_TRANID { get; private set; }
        public string APOLLO_PBH_ID { get; private set; }
        public string APOLLO_HPNS_UNIQUEID { get; private set; }
        public string APOLLO_HPNS_THREADID { get; private set; }
        public string APOLLO_HPNS_HOPID { get; private set; }
        public string APOLLO_MRDD_TRANID { get; private set; }
        public string APOLLO_BIN { get; private set; }
        public string APOLLO_PATIENTGENDERCODE { get; private set; }
        public string APOLLO_PATIENTZIPCODE { get; private set; }
        public string APOLLO_PERSONCODE { get; private set; }
        public string APOLLO_PRESCRIBERID { get; private set; }
        public string APOLLO_PRESCRIBERID2 { get; private set; }
        public string APOLLO_PRESCRIBERLASTNAME { get; private set; }
        public string APOLLO_PATPAYAMT { get; private set; }
        public string APOLLO_PRESCRIBERZIP { get; private set; }
        public string APOLLO_PCN { get; private set; }
        public string APOLLO_PRODUCTID { get; private set; }
        public string APOLLO_QUANTITY { get; private set; }
        public string APOLLO_RXNORM { get; private set; }
        public string APOLLO_SPONSOREDMESSAGE { get; private set; }
        public string APOLLO_ASSIGNEDRXSPI { get; private set; }
        public string APOLLO_ASSIGNEDRXNAME { get; private set; }
        public string APOLLO_ASSIGNEDRXADDRESS { get; private set; }
        public string APOLLO_ASSIGNEDRXCITY { get; private set; }
        public string APOLLO_ASSIGNEDRXSTATE { get; private set; }
        public string APOLLO_ASSIGNEDRXZIP { get; private set; }
        public string APOLLO_ASSIGNEDPHARMACYINDICATOR { get; private set; }
        public string APOLLO_RHPMESSAGEID { get; private set; }
        public string PPE_TranId { get; private set; }
        public string APOLLO_X { get; private set; }
        public string APOLLO_Y { get; private set; }
        public string APOLLO_Z { get; private set; }

        public NCPDP ParseRequestString(string request)
        {
            var requestStrSplit = request.Split(new char[] { (char)30, (char)29, (char)28 }, StringSplitOptions.None);
            var result = new NCPDP
            {
                BINNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("A1")),
                VersionReleaseNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("A2")),
                TransactionCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("A3")),
                ProcessorControlNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("A4")),
                TransactionCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("A9")),
                ServiceProviderIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("B2")),
                ServiceProviderID = requestStrSplit.FirstOrDefault(c => c.StartsWith("B1")),
                DateofService = requestStrSplit.FirstOrDefault(c => c.StartsWith("D1")),
                SoftwareVendor_CertificationID = requestStrSplit.FirstOrDefault(c => c.StartsWith("AK")),
                SegmentIdentification = requestStrSplit.FirstOrDefault(c => c.StartsWith("AM")),
                CardholderID = requestStrSplit.FirstOrDefault(c => c.StartsWith("C2")),
                CardholderFirstName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CC")),
                CardholderLastName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CD")),
                HomePlan = requestStrSplit.FirstOrDefault(c => c.StartsWith("CE")),
                PlanID = requestStrSplit.FirstOrDefault(c => c.StartsWith("FO")),
                EligibilityClarificationCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("C9")),
                GroupID = requestStrSplit.FirstOrDefault(c => c.StartsWith("C1")),
                PersonCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("C3")),
                PatientRelationshipCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("C6")),
                OtherPayerBINNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("MG")),
                OtherPayerProcessorControlNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("MH")),
                OtherPayerCardholderID = requestStrSplit.FirstOrDefault(c => c.StartsWith("NU")),
                OtherPayerGroupID = requestStrSplit.FirstOrDefault(c => c.StartsWith("MJ")),
                MedigapID = requestStrSplit.FirstOrDefault(c => c.StartsWith("2A")),
                MedicaidIndicator = requestStrSplit.FirstOrDefault(c => c.StartsWith("2B")),
                ProviderAcceptAssignmentIndicator = requestStrSplit.FirstOrDefault(c => c.StartsWith("2D")),
                CMSPartDDefinedQualifiedFacility = requestStrSplit.FirstOrDefault(c => c.StartsWith("G2")),
                MedicaidIDNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("N5")),
                MedicaidAgencyNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("N6")),
                PatientIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("CX")),
                PatientID = requestStrSplit.FirstOrDefault(c => c.StartsWith("CY")),
                DateofBirth = requestStrSplit.FirstOrDefault(c => c.StartsWith("C4")),
                PatientGenderCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("C5")),
                PatientFirstName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CA")),
                PatientLastName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CB")),
                PatientStreetAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("CM")),
                PatientCity = requestStrSplit.FirstOrDefault(c => c.StartsWith("CN")),
                PatientStateorProvince = requestStrSplit.FirstOrDefault(c => c.StartsWith("CO")),
                PatientZip_PostalCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("CP")),
                PatientPhonenumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("CQ")),
                PlaceofService = requestStrSplit.FirstOrDefault(c => c.StartsWith("C7")),
                EmployerID = requestStrSplit.FirstOrDefault(c => c.StartsWith("CZ")),
                Smoker_Non_smokerCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("1C")),
                PregnancyIndicator = requestStrSplit.FirstOrDefault(c => c.StartsWith("2C")),
                PatientE_MailAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("HN")),
                PatientResidence = requestStrSplit.FirstOrDefault(c => c.StartsWith("4X")),
                ProviderIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("EY")),
                ProviderID = requestStrSplit.FirstOrDefault(c => c.StartsWith("E9")),
                Prescription_ServiceReferenceNumberQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("EM")),
                Prescription_ServiceReferenceNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("D2")),
                Product_ServiceIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("E1")),
                Product_ServiceID = requestStrSplit.FirstOrDefault(c => c.StartsWith("D7")),
                AssociatedPrescription_ServiceReferenceNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("EN")),
                AssociatedPrescription_ServiceDate = requestStrSplit.FirstOrDefault(c => c.StartsWith("EP")),
                ProcedureModifierCodeCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("SE")),
                ProcedureModifierCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("ER")),
                QuantityDispensed = requestStrSplit.FirstOrDefault(c => c.StartsWith("E7")),
                FillNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("D3")),
                DaysSupply = requestStrSplit.FirstOrDefault(c => c.StartsWith("D5")),
                CompoundCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("D6")),
                DispenseasWritten_ProductSelectionCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("D8")),
                DatePrescriptionWritten = requestStrSplit.FirstOrDefault(c => c.StartsWith("DE")),
                NumberofRefillsAuthorized = requestStrSplit.FirstOrDefault(c => c.StartsWith("DF")),
                PrescriptionOriginCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("DJ")),
                SubmissionClarificationCodeCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("NX")),
                SubmissionClarificationCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("DK")),
                QuantityPrescribed = requestStrSplit.FirstOrDefault(c => c.StartsWith("ET")),
                OtherCoverageCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("C8")),
                SpecialPackagingIndicator = requestStrSplit.FirstOrDefault(c => c.StartsWith("DT")),
                OriginallyPrescribedProduct_ServiceIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("EJ")),
                OriginallyPrescribedProduct_ServiceCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("EA")),
                OriginallyPrescribedQuantity = requestStrSplit.FirstOrDefault(c => c.StartsWith("EB")),
                AlternateID = requestStrSplit.FirstOrDefault(c => c.StartsWith("CW")),
                ScheduledPrescriptionIDNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("EK")),
                UnitofMeasure = requestStrSplit.FirstOrDefault(c => c.StartsWith("28")),
                LevelofService = requestStrSplit.FirstOrDefault(c => c.StartsWith("DI")),
                PriorAuthorizationTypeCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("EU")),
                PriorAuthorizationNumberSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("EV")),
                IntermediaryAuthorizationTypeID = requestStrSplit.FirstOrDefault(c => c.StartsWith("EW")),
                IntermediaryAuthorizationID = requestStrSplit.FirstOrDefault(c => c.StartsWith("EX")),
                DispensingStatus = requestStrSplit.FirstOrDefault(c => c.StartsWith("HD")),
                QuantityIntendedtobeDispensed = requestStrSplit.FirstOrDefault(c => c.StartsWith("HF")),
                DaysSupplyIntendedtobeDispensed = requestStrSplit.FirstOrDefault(c => c.StartsWith("HG")),
                DelayReasonCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("NV")),
                TransactionReferenceNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("K5")),
                PatientAssignmentIndicator = requestStrSplit.FirstOrDefault(c => c.StartsWith("MT")),
                RouteofAdministration = requestStrSplit.FirstOrDefault(c => c.StartsWith("E2")),
                CompoundType = requestStrSplit.FirstOrDefault(c => c.StartsWith("G1")),
                MedicaidSubrogationInternalControlNumber_TransactionControlNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("N4")),
                PharmacyServiceType = requestStrSplit.FirstOrDefault(c => c.StartsWith("U7")),
                PrescriberIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("EZ")),
                PrescriberID = requestStrSplit.FirstOrDefault(c => c.StartsWith("DB")),
                PrescriberLastName = requestStrSplit.FirstOrDefault(c => c.StartsWith("DR")),
                PrescriberPhoneNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("PM")),
                PrimaryCareProviderIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("2E")),
                PrimaryCareProviderID = requestStrSplit.FirstOrDefault(c => c.StartsWith("DL")),
                PrimaryCareProviderLastName = requestStrSplit.FirstOrDefault(c => c.StartsWith("4E")),
                PrescriberFirstName = requestStrSplit.FirstOrDefault(c => c.StartsWith("2J")),
                PrescriberStreetAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("2K")),
                PrescriberCityAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("2M")),
                PrescriberState_ProvinceAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("2N")),
                PrescriberZIP_PostalZone = requestStrSplit.FirstOrDefault(c => c.StartsWith("2P")),
                CoordinationofBenefits_OtherPaymentsCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("4C")),
                OtherPayerCoverageType = requestStrSplit.FirstOrDefault(c => c.StartsWith("5C")),
                OtherPayerIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("6C")),
                OtherPayerID = requestStrSplit.FirstOrDefault(c => c.StartsWith("7C")),
                OtherPayerDate = requestStrSplit.FirstOrDefault(c => c.StartsWith("E8")),
                InternalControlNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("A7")),
                OtherPayerAmountPaidCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("HB")),
                OtherPayerAmountPaidQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("HC")),
                OtherPayerAmountPaid = requestStrSplit.FirstOrDefault(c => c.StartsWith("DV")),
                OtherPayerRejectCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("5E")),
                OtherPayerRejectCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("6E")),
                PatientResponsibilityAmountCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("NR")),
                PatientResponsibilityAmountQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("NP")),
                PatientResponsibilityAmount = requestStrSplit.FirstOrDefault(c => c.StartsWith("NQ")),
                BenefitStageCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("MU")),
                BenefitStageQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("MV")),
                BenefitStageAmount = requestStrSplit.FirstOrDefault(c => c.StartsWith("MW")),
                DateofInjury = requestStrSplit.FirstOrDefault(c => c.StartsWith("DY")),
                EmployerName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CF")),
                EmployerStreetAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("CG")),
                EmployerCityAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("CH")),
                ProvinceAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("CI")),
                PostalCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("CJ")),
                EmployerPhoneNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("CK")),
                EmployerContactName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CL")),
                CarrierID = requestStrSplit.FirstOrDefault(c => c.StartsWith("CR")),
                Claim_ReferenceID = requestStrSplit.FirstOrDefault(c => c.StartsWith("DZ")),
                BillingEntityTypeIndicator = requestStrSplit.FirstOrDefault(c => c.StartsWith("TR")),
                PayToQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("TS")),
                PayToID = requestStrSplit.FirstOrDefault(c => c.StartsWith("TT")),
                PayToName = requestStrSplit.FirstOrDefault(c => c.StartsWith("TU")),
                PayToStreetAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("TV")),
                PayToCityAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("TW")),
                PostalZone = requestStrSplit.FirstOrDefault(c => c.StartsWith("TY")),
                GenericEquivalentProductIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("TZ")),
                GenericEquivalentProductID = requestStrSplit.FirstOrDefault(c => c.StartsWith("UA")),
                DUR_PPSCodeCounter = requestStrSplit.FirstOrDefault(c => c.StartsWith("7E")),
                ReasonforServiceCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("E4")),
                ProfessionalServiceCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("E5")),
                ResultofServiceCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("E6")),
                DUR_PPSLevelofEffort = requestStrSplit.FirstOrDefault(c => c.StartsWith("8E")),
                DURCo_AgentIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("J9")),
                DURCo_AgentID = requestStrSplit.FirstOrDefault(c => c.StartsWith("H6")),
                IngredientCostSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("D9")),
                DispensingFeeSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("DC")),
                ProfessionalServiceFeeSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("BE")),
                PatientPaidAmountSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("DX")),
                IncentiveAmountSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("E3")),
                OtherAmountClaimedSubmittedCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("H7")),
                OtherAmountClaimedSubmittedQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("H8")),
                OtherAmountClaimedSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("H9")),
                FlatSalesTaxAmountSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("HA")),
                PercentageSalesTaxAmountSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("GE")),
                PercentageSalesTaxRateSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("HE")),
                PercentageSalesTaxBasisSubmitted = requestStrSplit.FirstOrDefault(c => c.StartsWith("JE")),
                UsualandCustomaryCharge = requestStrSplit.FirstOrDefault(c => c.StartsWith("DQ")),
                GrossAmountDue = requestStrSplit.FirstOrDefault(c => c.StartsWith("DU")),
                BasisofCostDetermination = requestStrSplit.FirstOrDefault(c => c.StartsWith("DN")),
                MedicaidPaidAmount = requestStrSplit.FirstOrDefault(c => c.StartsWith("N3")),
                CouponType = requestStrSplit.FirstOrDefault(c => c.StartsWith("KE")),
                CouponNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("ME")),
                CouponValueAmount = requestStrSplit.FirstOrDefault(c => c.StartsWith("NE")),
                CompoundDosageFormDescriptionCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("EF")),
                CompoundDispensingUnitFormIndicator = requestStrSplit.FirstOrDefault(c => c.StartsWith("EG")),
                CompoundIngredientComponentCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("EC")),
                CompoundProductIDQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("RE")),
                CompoundProductID = requestStrSplit.FirstOrDefault(c => c.StartsWith("TE")),
                CompoundIngredientQuantity = requestStrSplit.FirstOrDefault(c => c.StartsWith("ED")),
                CompoundIngredientDrugCost = requestStrSplit.FirstOrDefault(c => c.StartsWith("EE")),
                CompoundIngredientBasisofCostDetermination = requestStrSplit.FirstOrDefault(c => c.StartsWith("UE")),
                CompoundIngredientModifierCodeCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("2G")),
                CompoundIngredientModifierCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("2H")),
                RequestType = requestStrSplit.FirstOrDefault(c => c.StartsWith("PA")),
                RequestPeriodDate_Begin = requestStrSplit.FirstOrDefault(c => c.StartsWith("PB")),
                RequestPeriodDate_End = requestStrSplit.FirstOrDefault(c => c.StartsWith("PC")),
                BasisofRequest = requestStrSplit.FirstOrDefault(c => c.StartsWith("PD")),
                AuthorizedRepresentativeFirstName = requestStrSplit.FirstOrDefault(c => c.StartsWith("PE")),
                AuthorizedRep_LastName = requestStrSplit.FirstOrDefault(c => c.StartsWith("PF")),
                AuthorizedRep_StreetAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("PG")),
                AuthorizedRep_City = requestStrSplit.FirstOrDefault(c => c.StartsWith("PH")),
                AuthorizedRep_State_Province = requestStrSplit.FirstOrDefault(c => c.StartsWith("PJ")),
                AuthorizedRep_Zip_PostalCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("PK")),
                PriorAuthorizationNumber_Assigned = requestStrSplit.FirstOrDefault(c => c.StartsWith("PY")),
                AuthorizationNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("F3")),
                PriorAuthorizationSupportingDocumentation = requestStrSplit.FirstOrDefault(c => c.StartsWith("PP")),
                DiagnosisCodeCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("VE")),
                DiagnosisCodeQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("WE")),
                DiagnosisCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("DO")),
                ClinicalInformationCounter = requestStrSplit.FirstOrDefault(c => c.StartsWith("XE")),
                MeasurementDate = requestStrSplit.FirstOrDefault(c => c.StartsWith("ZE")),
                MeasurementTime = requestStrSplit.FirstOrDefault(c => c.StartsWith("H1")),
                MeasurementDimension = requestStrSplit.FirstOrDefault(c => c.StartsWith("H2")),
                MeasurementUnit = requestStrSplit.FirstOrDefault(c => c.StartsWith("H3")),
                MeasurementValue = requestStrSplit.FirstOrDefault(c => c.StartsWith("H4")),
                AdditionalDocumentationTypeID = requestStrSplit.FirstOrDefault(c => c.StartsWith("2Q")),
                RequestPeriodBeginDate = requestStrSplit.FirstOrDefault(c => c.StartsWith("2V")),
                RequestPeriodRecert_RevisedDate = requestStrSplit.FirstOrDefault(c => c.StartsWith("2W")),
                RequestStatus = requestStrSplit.FirstOrDefault(c => c.StartsWith("2U")),
                LengthOfNeedQualifier = requestStrSplit.FirstOrDefault(c => c.StartsWith("2S")),
                LengthOfNeed = requestStrSplit.FirstOrDefault(c => c.StartsWith("2R")),
                SupplierDateSigned = requestStrSplit.FirstOrDefault(c => c.StartsWith("2T")),
                SupportingDocumentation = requestStrSplit.FirstOrDefault(c => c.StartsWith("2X")),
                LetterCount = requestStrSplit.FirstOrDefault(c => c.StartsWith("2Z")),
                Letter = requestStrSplit.FirstOrDefault(c => c.StartsWith("4B")),
                QuestionPercentResponse = requestStrSplit.FirstOrDefault(c => c.StartsWith("4D")),
                QuestionDateResponse = requestStrSplit.FirstOrDefault(c => c.StartsWith("4G")),
                QuestionDollarAmountResponse = requestStrSplit.FirstOrDefault(c => c.StartsWith("4H")),
                QuestionNumericResponse = requestStrSplit.FirstOrDefault(c => c.StartsWith("4J")),
                QuestionAlphanumericResponse = requestStrSplit.FirstOrDefault(c => c.StartsWith("4K")),
                FacilityID = requestStrSplit.FirstOrDefault(c => c.StartsWith("8C")),
                FacilityName = requestStrSplit.FirstOrDefault(c => c.StartsWith("3Q")),
                FacilityStreetAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("3U")),
                FacilityCityAddress = requestStrSplit.FirstOrDefault(c => c.StartsWith("5J")),
                NarrativeMessage = requestStrSplit.FirstOrDefault(c => c.StartsWith("BM")),
                SEGMENTIDENTIFICATION = requestStrSplit.FirstOrDefault(c => c.StartsWith("AM")),
                PMC_ADDITIONAL_MESSAGES = requestStrSplit.FirstOrDefault(c => c.StartsWith("_J")),
                PMC_PATIENT_ID_PMC_RESIDENT_ID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_K")),
                PMC_PATIENT_ID_NURSING_HOME_RESIDENT_NUMBER = requestStrSplit.FirstOrDefault(c => c.StartsWith("_L")),
                PMC_PATIENT_ID_ALTERNATE_RESIDENT_ID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_M")),
                PMC_PATIENT_ID_SOCIAL_SECURITY_NUM = requestStrSplit.FirstOrDefault(c => c.StartsWith("_N")),
                PMC_PATIENT_ID_MEDICARE_NUM = requestStrSplit.FirstOrDefault(c => c.StartsWith("_O")),
                PMC_PATIENT_ID_MEDICAID_NUM = requestStrSplit.FirstOrDefault(c => c.StartsWith("_P")),
                PMC_PATIENT_ID_POLICY_HOLDER_NUM = requestStrSplit.FirstOrDefault(c => c.StartsWith("_Q")),
                PMC_PATIENT_ID_POLICY_NUM = requestStrSplit.FirstOrDefault(c => c.StartsWith("_R")),
                APOLLO_CUSTOM_JSON_FIELDS = requestStrSplit.FirstOrDefault(c => c.StartsWith("_0")),
                APOLLO_RESPONSE_SOURCE_FLAG = requestStrSplit.FirstOrDefault(c => c.StartsWith("_1")),
                APOLLO_REASONCODE = requestStrSplit.FirstOrDefault(c => c.StartsWith("_2")),
                APOLLO_MESSAGE = requestStrSplit.FirstOrDefault(c => c.StartsWith("_3")),
                APOLLO_PBH_TRANID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_4")),
                APOLLO_PBH_ID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_5")),
                APOLLO_HPNS_UNIQUEID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_6")),
                APOLLO_HPNS_THREADID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_7")),
                APOLLO_HPNS_HOPID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_8")),
                APOLLO_MRDD_TRANID = requestStrSplit.FirstOrDefault(c => c.StartsWith("_9")),
                APOLLO_BIN = requestStrSplit.FirstOrDefault(c => c.StartsWith("A")),
                APOLLO_PATIENTGENDERCODE = requestStrSplit.FirstOrDefault(c => c.StartsWith("B")),
                APOLLO_PATIENTZIPCODE = requestStrSplit.FirstOrDefault(c => c.StartsWith("C")),
                APOLLO_PERSONCODE = requestStrSplit.FirstOrDefault(c => c.StartsWith("D")),
                APOLLO_PRESCRIBERID = requestStrSplit.FirstOrDefault(c => c.StartsWith("E")),
                APOLLO_PRESCRIBERID2 = requestStrSplit.FirstOrDefault(c => c.StartsWith("F")),
                APOLLO_PRESCRIBERLASTNAME = requestStrSplit.FirstOrDefault(c => c.StartsWith("G")),
                APOLLO_PATPAYAMT = requestStrSplit.FirstOrDefault(c => c.StartsWith("H")),
                APOLLO_PRESCRIBERZIP = requestStrSplit.FirstOrDefault(c => c.StartsWith("I")),
                APOLLO_PCN = requestStrSplit.FirstOrDefault(c => c.StartsWith("J")),
                APOLLO_PRODUCTID = requestStrSplit.FirstOrDefault(c => c.StartsWith("K")),
                APOLLO_QUANTITY = requestStrSplit.FirstOrDefault(c => c.StartsWith("L")),
                APOLLO_RXNORM = requestStrSplit.FirstOrDefault(c => c.StartsWith("M")),
                APOLLO_SPONSOREDMESSAGE = requestStrSplit.FirstOrDefault(c => c.StartsWith("N")),
                APOLLO_ASSIGNEDRXSPI = requestStrSplit.FirstOrDefault(c => c.StartsWith("O")),
                APOLLO_ASSIGNEDRXNAME = requestStrSplit.FirstOrDefault(c => c.StartsWith("P")),
                APOLLO_ASSIGNEDRXADDRESS = requestStrSplit.FirstOrDefault(c => c.StartsWith("Q")),
                APOLLO_ASSIGNEDRXCITY = requestStrSplit.FirstOrDefault(c => c.StartsWith("R")),
                APOLLO_ASSIGNEDRXSTATE = requestStrSplit.FirstOrDefault(c => c.StartsWith("S")),
                APOLLO_ASSIGNEDRXZIP = requestStrSplit.FirstOrDefault(c => c.StartsWith("T")),
                APOLLO_ASSIGNEDPHARMACYINDICATOR = requestStrSplit.FirstOrDefault(c => c.StartsWith("U")),
                APOLLO_RHPMESSAGEID = requestStrSplit.FirstOrDefault(c => c.StartsWith("V")),
                PPE_TranId = requestStrSplit.FirstOrDefault(c => c.StartsWith("W")),
                APOLLO_X = requestStrSplit.FirstOrDefault(c => c.StartsWith("X")),
                APOLLO_Y = requestStrSplit.FirstOrDefault(c => c.StartsWith("Y")),
                APOLLO_Z = requestStrSplit.FirstOrDefault(c => c.StartsWith("Z"))
            };
            return result;
        }
    }
}
