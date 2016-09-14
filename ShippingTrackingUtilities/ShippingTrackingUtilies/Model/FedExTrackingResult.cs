﻿namespace ShippingTrackingUtilities.FedExTrackingResult
{
    //------------------------------------------------------------------------------
    // <auto-generated>
    //     This code was generated by a tool.
    //     Runtime Version:4.0.30319.42000
    //
    //     Changes to this file may cause incorrect behavior and will be lost if
    //     the code is regenerated.
    // </auto-generated>
    //------------------------------------------------------------------------------

    using System.Xml.Serialization;

    // 
    // This source code was auto-generated by xsd, Version=4.0.30319.18020.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://fedex.com/ws/track/v3", IsNullable = false)]
    public partial class TrackReply
    {

        private string highestSeverityField;

        private string messageField;

        private string duplicateWaybillField;

        private string moreDataField;

        private TrackReplyNotifications[] notificationsField;

        private TrackReplyTransactionDetail[] transactionDetailField;

        private TrackReplyVersion[] versionField;

        private TrackReplyTrackDetails[] trackDetailsField;

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string HighestSeverity
        {
            get
            {
                return this.highestSeverityField;
            }
            set
            {
                this.highestSeverityField = value;
            }
        }

        /// <remarks/>
        public string DuplicateWaybill
        {
            get
            {
                return this.duplicateWaybillField;
            }
            set
            {
                this.duplicateWaybillField = value;
            }
        }

        /// <remarks/>
        public string MoreData
        {
            get
            {
                return this.moreDataField;
            }
            set
            {
                this.moreDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Notifications")]
        public TrackReplyNotifications[] Notifications
        {
            get
            {
                return this.notificationsField;
            }
            set
            {
                this.notificationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransactionDetail")]
        public TrackReplyTransactionDetail[] TransactionDetail
        {
            get
            {
                return this.transactionDetailField;
            }
            set
            {
                this.transactionDetailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Version")]
        public TrackReplyVersion[] Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TrackDetails")]
        public TrackReplyTrackDetails[] TrackDetails
        {
            get
            {
                return this.trackDetailsField;
            }
            set
            {
                this.trackDetailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyNotifications
    {

        private string severityField;

        private string sourceField;

        private string codeField;

        private string messageField;

        private string localizedMessageField;

        /// <remarks/>
        public string Severity
        {
            get
            {
                return this.severityField;
            }
            set
            {
                this.severityField = value;
            }
        }

        /// <remarks/>
        public string Source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string LocalizedMessage
        {
            get
            {
                return this.localizedMessageField;
            }
            set
            {
                this.localizedMessageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTransactionDetail
    {

        private string customerTransactionIdField;

        /// <remarks/>
        public string CustomerTransactionId
        {
            get
            {
                return this.customerTransactionIdField;
            }
            set
            {
                this.customerTransactionIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyVersion
    {

        private string serviceIdField;

        private string majorField;

        private string intermediateField;

        private string minorField;

        /// <remarks/>
        public string ServiceId
        {
            get
            {
                return this.serviceIdField;
            }
            set
            {
                this.serviceIdField = value;
            }
        }

        /// <remarks/>
        public string Major
        {
            get
            {
                return this.majorField;
            }
            set
            {
                this.majorField = value;
            }
        }

        /// <remarks/>
        public string Intermediate
        {
            get
            {
                return this.intermediateField;
            }
            set
            {
                this.intermediateField = value;
            }
        }

        /// <remarks/>
        public string Minor
        {
            get
            {
                return this.minorField;
            }
            set
            {
                this.minorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetails
    {

        private string trackingNumberField;

        private string trackingNumberUniqueIdentifierField;

        private string statusCodeField;

        private string statusDescriptionField;

        private string carrierCodeField;

        private string serviceInfoField;

        private string serviceTypeField;

        private string packagingField;

        private string packagingTypeField;

        private string packageSequenceNumberField;

        private string packageCountField;

        private string shipTimestampField;

        private string actualDeliveryTimestampField;

        private string estimatedDeliveryTimestamp;

        private string deliverySignatureNameField;

        private string signatureProofOfDeliveryAvailableField;

        private string proofOfDeliveryNotificationsAvailableField;

        private TrackReplyTrackDetailsNotification[] notificationField;

        private TrackReplyTrackDetailsOtherIdentifiers[] otherIdentifiersField;

        private TrackReplyTrackDetailsPackageWeight[] packageWeightField;

        private TrackReplyTrackDetailsShipperAddress[] shipperAddressField;

        private TrackReplyTrackDetailsOriginLocationAddress[] originLocationAddressField;

        private TrackReplyTrackDetailsDestinationAddress[] destinationAddressField;

        private TrackReplyTrackDetailsActualDeliveryAddress[] actualDeliveryAddressField;

        private TrackReplyTrackDetailsEvents[] eventsField;

        /// <remarks/>
        public string TrackingNumber
        {
            get
            {
                return this.trackingNumberField;
            }
            set
            {
                this.trackingNumberField = value;
            }
        }

        /// <remarks/>
        public string TrackingNumberUniqueIdentifier
        {
            get
            {
                return this.trackingNumberUniqueIdentifierField;
            }
            set
            {
                this.trackingNumberUniqueIdentifierField = value;
            }
        }

        /// <remarks/>
        public string StatusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }

        /// <remarks/>
        public string StatusDescription
        {
            get
            {
                return this.statusDescriptionField;
            }
            set
            {
                this.statusDescriptionField = value;
            }
        }

        /// <remarks/>
        public string CarrierCode
        {
            get
            {
                return this.carrierCodeField;
            }
            set
            {
                this.carrierCodeField = value;
            }
        }

        /// <remarks/>
        public string ServiceInfo
        {
            get
            {
                return this.serviceInfoField;
            }
            set
            {
                this.serviceInfoField = value;
            }
        }

        /// <remarks/>
        public string ServiceType
        {
            get
            {
                return this.serviceTypeField;
            }
            set
            {
                this.serviceTypeField = value;
            }
        }

        /// <remarks/>
        public string Packaging
        {
            get
            {
                return this.packagingField;
            }
            set
            {
                this.packagingField = value;
            }
        }

        /// <remarks/>
        public string PackagingType
        {
            get
            {
                return this.packagingTypeField;
            }
            set
            {
                this.packagingTypeField = value;
            }
        }

        /// <remarks/>
        public string PackageSequenceNumber
        {
            get
            {
                return this.packageSequenceNumberField;
            }
            set
            {
                this.packageSequenceNumberField = value;
            }
        }

        /// <remarks/>
        public string PackageCount
        {
            get
            {
                return this.packageCountField;
            }
            set
            {
                this.packageCountField = value;
            }
        }

        /// <remarks/>
        public string ShipTimestamp
        {
            get
            {
                return this.shipTimestampField;
            }
            set
            {
                this.shipTimestampField = value;
            }
        }

        /// <remarks/>
        public string ActualDeliveryTimestamp
        {
            get
            {
                return this.actualDeliveryTimestampField;
            }
            set
            {
                this.actualDeliveryTimestampField = value;
            }
        }

        /// <remarks/>
        public string EstimatedDeliveryTimestamp
        {
            get
            {
                return this.estimatedDeliveryTimestamp;
            }
            set
            {
                this.estimatedDeliveryTimestamp = value;
            }
        }
 
        /// <remarks/>
        public string DeliverySignatureName
        {
            get
            {
                return this.deliverySignatureNameField;
            }
            set
            {
                this.deliverySignatureNameField = value;
            }
        }

        /// <remarks/>
        public string SignatureProofOfDeliveryAvailable
        {
            get
            {
                return this.signatureProofOfDeliveryAvailableField;
            }
            set
            {
                this.signatureProofOfDeliveryAvailableField = value;
            }
        }

        /// <remarks/>
        public string ProofOfDeliveryNotificationsAvailable
        {
            get
            {
                return this.proofOfDeliveryNotificationsAvailableField;
            }
            set
            {
                this.proofOfDeliveryNotificationsAvailableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Notification")]
        public TrackReplyTrackDetailsNotification[] Notification
        {
            get
            {
                return this.notificationField;
            }
            set
            {
                this.notificationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherIdentifiers")]
        public TrackReplyTrackDetailsOtherIdentifiers[] OtherIdentifiers
        {
            get
            {
                return this.otherIdentifiersField;
            }
            set
            {
                this.otherIdentifiersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PackageWeight")]
        public TrackReplyTrackDetailsPackageWeight[] PackageWeight
        {
            get
            {
                return this.packageWeightField;
            }
            set
            {
                this.packageWeightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ShipperAddress")]
        public TrackReplyTrackDetailsShipperAddress[] ShipperAddress
        {
            get
            {
                return this.shipperAddressField;
            }
            set
            {
                this.shipperAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OriginLocationAddress")]
        public TrackReplyTrackDetailsOriginLocationAddress[] OriginLocationAddress
        {
            get
            {
                return this.originLocationAddressField;
            }
            set
            {
                this.originLocationAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DestinationAddress")]
        public TrackReplyTrackDetailsDestinationAddress[] DestinationAddress
        {
            get
            {
                return this.destinationAddressField;
            }
            set
            {
                this.destinationAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActualDeliveryAddress")]
        public TrackReplyTrackDetailsActualDeliveryAddress[] ActualDeliveryAddress
        {
            get
            {
                return this.actualDeliveryAddressField;
            }
            set
            {
                this.actualDeliveryAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Events")]
        public TrackReplyTrackDetailsEvents[] Events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsNotification
    {

        private string severityField;

        private string sourceField;

        private string codeField;

        private string messageField;

        private string localizedMessageField;

        /// <remarks/>
        public string Severity
        {
            get
            {
                return this.severityField;
            }
            set
            {
                this.severityField = value;
            }
        }

        /// <remarks/>
        public string Source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string LocalizedMessage
        {
            get
            {
                return this.localizedMessageField;
            }
            set
            {
                this.localizedMessageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsOtherIdentifiers
    {

        private string valueField;

        private string typeField;

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsPackageWeight
    {

        private string unitsField;

        private string valueField;

        /// <remarks/>
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsShipperAddress
    {

        private string cityField;

        private string stateOrProvinceCodeField;

        private string countryCodeField;

        private string residentialField;

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string StateOrProvinceCode
        {
            get
            {
                return this.stateOrProvinceCodeField;
            }
            set
            {
                this.stateOrProvinceCodeField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string Residential
        {
            get
            {
                return this.residentialField;
            }
            set
            {
                this.residentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsOriginLocationAddress
    {

        private string cityField;

        private string stateOrProvinceCodeField;

        private string countryCodeField;

        private string residentialField;

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string StateOrProvinceCode
        {
            get
            {
                return this.stateOrProvinceCodeField;
            }
            set
            {
                this.stateOrProvinceCodeField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string Residential
        {
            get
            {
                return this.residentialField;
            }
            set
            {
                this.residentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsDestinationAddress
    {

        private string cityField;

        private string stateOrProvinceCodeField;

        private string countryCodeField;

        private string residentialField;

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string StateOrProvinceCode
        {
            get
            {
                return this.stateOrProvinceCodeField;
            }
            set
            {
                this.stateOrProvinceCodeField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string Residential
        {
            get
            {
                return this.residentialField;
            }
            set
            {
                this.residentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsActualDeliveryAddress
    {

        private string cityField;

        private string stateOrProvinceCodeField;

        private string countryCodeField;

        private string residentialField;

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string StateOrProvinceCode
        {
            get
            {
                return this.stateOrProvinceCodeField;
            }
            set
            {
                this.stateOrProvinceCodeField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string Residential
        {
            get
            {
                return this.residentialField;
            }
            set
            {
                this.residentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsEvents
    {

        private string timestampField;

        private string eventTypeField;

        private string eventDescriptionField;

        private TrackReplyTrackDetailsEventsAddress[] addressField;

        /// <remarks/>
        public string Timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        public string EventType
        {
            get
            {
                return this.eventTypeField;
            }
            set
            {
                this.eventTypeField = value;
            }
        }

        /// <remarks/>
        public string EventDescription
        {
            get
            {
                return this.eventDescriptionField;
            }
            set
            {
                this.eventDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Address")]
        public TrackReplyTrackDetailsEventsAddress[] Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    public partial class TrackReplyTrackDetailsEventsAddress
    {

        private string cityField;

        private string stateOrProvinceCodeField;

        private string postalCodeField;

        private string countryCodeField;

        private string residentialField;

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string StateOrProvinceCode
        {
            get
            {
                return this.stateOrProvinceCodeField;
            }
            set
            {
                this.stateOrProvinceCodeField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public string Residential
        {
            get
            {
                return this.residentialField;
            }
            set
            {
                this.residentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fedex.com/ws/track/v3")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://fedex.com/ws/track/v3", IsNullable = false)]
    public partial class NewDataSet
    {

        private TrackReply[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TrackReply")]
        public TrackReply[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

}