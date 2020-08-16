using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace invoiceplane_apis.Models
{
    public partial class invoiceplane_dbContext : DbContext
    { 
        public invoiceplane_dbContext()
        {
        }

        public invoiceplane_dbContext(DbContextOptions<invoiceplane_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IpClientCustom> IpClientCustom { get; set; }
        public virtual DbSet<IpClientNotes> IpClientNotes { get; set; }
        public virtual DbSet<IpClients> IpClients { get; set; }
        public virtual DbSet<IpCustomFields> IpCustomFields { get; set; }
        public virtual DbSet<IpCustomValues> IpCustomValues { get; set; }
        public virtual DbSet<IpEmailTemplates> IpEmailTemplates { get; set; }
        public virtual DbSet<IpFamilies> IpFamilies { get; set; }
        public virtual DbSet<IpImportDetails> IpImportDetails { get; set; }
        public virtual DbSet<IpImports> IpImports { get; set; }
        public virtual DbSet<IpInvoiceAmounts> IpInvoiceAmounts { get; set; }
        public virtual DbSet<IpInvoiceCustom> IpInvoiceCustom { get; set; }
        public virtual DbSet<IpInvoiceGroups> IpInvoiceGroups { get; set; }
        public virtual DbSet<IpInvoiceItemAmounts> IpInvoiceItemAmounts { get; set; }
        public virtual DbSet<IpInvoiceItems> IpInvoiceItems { get; set; }
        public virtual DbSet<IpInvoiceSumex> IpInvoiceSumex { get; set; }
        public virtual DbSet<IpInvoiceTaxRates> IpInvoiceTaxRates { get; set; }
        public virtual DbSet<IpInvoices> IpInvoices { get; set; }
        public virtual DbSet<IpInvoicesRecurring> IpInvoicesRecurring { get; set; }
        public virtual DbSet<IpItemLookups> IpItemLookups { get; set; }
        public virtual DbSet<IpMerchantResponses> IpMerchantResponses { get; set; }
        public virtual DbSet<IpPaymentCustom> IpPaymentCustom { get; set; }
        public virtual DbSet<IpPaymentMethods> IpPaymentMethods { get; set; }
        public virtual DbSet<IpPayments> IpPayments { get; set; }
        public virtual DbSet<IpProducts> IpProducts { get; set; }
        public virtual DbSet<IpProjects> IpProjects { get; set; }
        public virtual DbSet<IpQuoteAmounts> IpQuoteAmounts { get; set; }
        public virtual DbSet<IpQuoteCustom> IpQuoteCustom { get; set; }
        public virtual DbSet<IpQuoteItemAmounts> IpQuoteItemAmounts { get; set; }
        public virtual DbSet<IpQuoteItems> IpQuoteItems { get; set; }
        public virtual DbSet<IpQuoteTaxRates> IpQuoteTaxRates { get; set; }
        public virtual DbSet<IpQuotes> IpQuotes { get; set; }
        public virtual DbSet<IpSessions> IpSessions { get; set; }
        public virtual DbSet<IpSettings> IpSettings { get; set; }
        public virtual DbSet<IpTasks> IpTasks { get; set; }
        public virtual DbSet<IpTaxRates> IpTaxRates { get; set; }
        public virtual DbSet<IpUnits> IpUnits { get; set; }
        public virtual DbSet<IpUploads> IpUploads { get; set; }
        public virtual DbSet<IpUserClients> IpUserClients { get; set; }
        public virtual DbSet<IpUserCustom> IpUserCustom { get; set; }
        public virtual DbSet<IpUsers> IpUsers { get; set; }
        public virtual DbSet<IpVersions> IpVersions { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IpClientCustom>(entity =>
            {
                entity.HasKey(e => e.ClientCustomId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_client_custom");

                entity.HasIndex(e => new { e.ClientId, e.ClientCustomFieldid })
                    .HasName("client_id")
                    .IsUnique();

                entity.Property(e => e.ClientCustomId)
                    .HasColumnName("client_custom_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientCustomFieldid)
                    .HasColumnName("client_custom_fieldid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientCustomFieldvalue).HasColumnName("client_custom_fieldvalue");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpClientNotes>(entity =>
            {
                entity.HasKey(e => e.ClientNoteId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_client_notes");

                entity.HasIndex(e => new { e.ClientId, e.ClientNoteDate })
                    .HasName("client_id");

                entity.Property(e => e.ClientNoteId)
                    .HasColumnName("client_note_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientNote)
                    .IsRequired()
                    .HasColumnName("client_note")
                    .HasColumnType("longtext");

                entity.Property(e => e.ClientNoteDate)
                    .HasColumnName("client_note_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<IpClients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_clients");

                entity.HasIndex(e => e.ClientActive)
                    .HasName("client_active");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientActive)
                    .HasColumnName("client_active")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ClientAddress1).HasColumnName("client_address_1");

                entity.Property(e => e.ClientAddress2).HasColumnName("client_address_2");

                entity.Property(e => e.ClientAvs)
                    .HasColumnName("client_avs")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ClientBirthdate)
                    .HasColumnName("client_birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.ClientCity).HasColumnName("client_city");

                entity.Property(e => e.ClientCountry).HasColumnName("client_country");

                entity.Property(e => e.ClientDateCreated).HasColumnName("client_date_created");

                entity.Property(e => e.ClientDateModified).HasColumnName("client_date_modified");

                entity.Property(e => e.ClientEmail).HasColumnName("client_email");

                entity.Property(e => e.ClientFax).HasColumnName("client_fax");

                entity.Property(e => e.ClientGender)
                    .HasColumnName("client_gender")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ClientInsurednumber)
                    .HasColumnName("client_insurednumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClientLanguage)
                    .HasColumnName("client_language")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'system'");

                entity.Property(e => e.ClientMobile).HasColumnName("client_mobile");

                entity.Property(e => e.ClientName).HasColumnName("client_name");

                entity.Property(e => e.ClientPhone).HasColumnName("client_phone");

                entity.Property(e => e.ClientState).HasColumnName("client_state");

                entity.Property(e => e.ClientSurname)
                    .HasColumnName("client_surname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientTaxCode).HasColumnName("client_tax_code");

                entity.Property(e => e.ClientVatId).HasColumnName("client_vat_id");

                entity.Property(e => e.ClientVeka)
                    .HasColumnName("client_veka")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClientWeb).HasColumnName("client_web");

                entity.Property(e => e.ClientZip).HasColumnName("client_zip");
            });

            modelBuilder.Entity<IpCustomFields>(entity =>
            {
                entity.HasKey(e => e.CustomFieldId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_custom_fields");

                entity.HasIndex(e => e.CustomFieldTable)
                    .HasName("custom_field_table");

                entity.HasIndex(e => new { e.CustomFieldTable, e.CustomFieldLabel })
                    .HasName("custom_field_table_2")
                    .IsUnique();

                entity.Property(e => e.CustomFieldId)
                    .HasColumnName("custom_field_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomFieldLabel)
                    .HasColumnName("custom_field_label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomFieldLocation)
                    .HasColumnName("custom_field_location")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CustomFieldOrder)
                    .HasColumnName("custom_field_order")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'999'");

                entity.Property(e => e.CustomFieldTable)
                    .HasColumnName("custom_field_table")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomFieldType)
                    .IsRequired()
                    .HasColumnName("custom_field_type")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'TEXT'");
            });

            modelBuilder.Entity<IpCustomValues>(entity =>
            {
                entity.HasKey(e => e.CustomValuesId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_custom_values");

                entity.Property(e => e.CustomValuesId)
                    .HasColumnName("custom_values_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomValuesField)
                    .HasColumnName("custom_values_field")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomValuesValue)
                    .IsRequired()
                    .HasColumnName("custom_values_value");
            });

            modelBuilder.Entity<IpEmailTemplates>(entity =>
            {
                entity.HasKey(e => e.EmailTemplateId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_email_templates");

                entity.Property(e => e.EmailTemplateId)
                    .HasColumnName("email_template_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmailTemplateBcc).HasColumnName("email_template_bcc");

                entity.Property(e => e.EmailTemplateBody)
                    .IsRequired()
                    .HasColumnName("email_template_body")
                    .HasColumnType("longtext");

                entity.Property(e => e.EmailTemplateCc).HasColumnName("email_template_cc");

                entity.Property(e => e.EmailTemplateFromEmail).HasColumnName("email_template_from_email");

                entity.Property(e => e.EmailTemplateFromName).HasColumnName("email_template_from_name");

                entity.Property(e => e.EmailTemplatePdfTemplate)
                    .HasColumnName("email_template_pdf_template")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailTemplateSubject).HasColumnName("email_template_subject");

                entity.Property(e => e.EmailTemplateTitle).HasColumnName("email_template_title");

                entity.Property(e => e.EmailTemplateType)
                    .HasColumnName("email_template_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IpFamilies>(entity =>
            {
                entity.HasKey(e => e.FamilyId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_families");

                entity.Property(e => e.FamilyId)
                    .HasColumnName("family_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FamilyName).HasColumnName("family_name");
            });

            modelBuilder.Entity<IpImportDetails>(entity =>
            {
                entity.HasKey(e => e.ImportDetailId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_import_details");

                entity.HasIndex(e => new { e.ImportId, e.ImportRecordId })
                    .HasName("import_id");

                entity.Property(e => e.ImportDetailId)
                    .HasColumnName("import_detail_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImportId)
                    .HasColumnName("import_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImportLangKey)
                    .IsRequired()
                    .HasColumnName("import_lang_key")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ImportRecordId)
                    .HasColumnName("import_record_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImportTableName)
                    .IsRequired()
                    .HasColumnName("import_table_name")
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IpImports>(entity =>
            {
                entity.HasKey(e => e.ImportId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_imports");

                entity.Property(e => e.ImportId)
                    .HasColumnName("import_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImportDate).HasColumnName("import_date");
            });

            modelBuilder.Entity<IpInvoiceAmounts>(entity =>
            {
                entity.HasKey(e => e.InvoiceAmountId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoice_amounts");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.HasIndex(e => new { e.InvoicePaid, e.InvoiceBalance })
                    .HasName("invoice_paid");

                entity.Property(e => e.InvoiceAmountId)
                    .HasColumnName("invoice_amount_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceBalance)
                    .HasColumnName("invoice_balance")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceItemSubtotal)
                    .HasColumnName("invoice_item_subtotal")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.InvoiceItemTaxTotal)
                    .HasColumnName("invoice_item_tax_total")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.InvoicePaid)
                    .HasColumnName("invoice_paid")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.InvoiceSign)
                    .IsRequired()
                    .HasColumnName("invoice_sign")
                    .HasColumnType("enum('1','-1')")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.InvoiceTaxTotal)
                    .HasColumnName("invoice_tax_total")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.InvoiceTotal)
                    .HasColumnName("invoice_total")
                    .HasColumnType("decimal(20,2)");
            });

            modelBuilder.Entity<IpInvoiceCustom>(entity =>
            {
                entity.HasKey(e => e.InvoiceCustomId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoice_custom");

                entity.HasIndex(e => new { e.InvoiceId, e.InvoiceCustomFieldid })
                    .HasName("invoice_id")
                    .IsUnique();

                entity.Property(e => e.InvoiceCustomId)
                    .HasColumnName("invoice_custom_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceCustomFieldid)
                    .HasColumnName("invoice_custom_fieldid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceCustomFieldvalue).HasColumnName("invoice_custom_fieldvalue");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpInvoiceGroups>(entity =>
            {
                entity.HasKey(e => e.InvoiceGroupId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoice_groups");

                entity.HasIndex(e => e.InvoiceGroupLeftPad)
                    .HasName("invoice_group_left_pad");

                entity.HasIndex(e => e.InvoiceGroupNextId)
                    .HasName("invoice_group_next_id");

                entity.Property(e => e.InvoiceGroupId)
                    .HasColumnName("invoice_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceGroupIdentifierFormat)
                    .IsRequired()
                    .HasColumnName("invoice_group_identifier_format")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceGroupLeftPad)
                    .HasColumnName("invoice_group_left_pad")
                    .HasColumnType("int(2)");

                entity.Property(e => e.InvoiceGroupName).HasColumnName("invoice_group_name");

                entity.Property(e => e.InvoiceGroupNextId)
                    .HasColumnName("invoice_group_next_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpInvoiceItemAmounts>(entity =>
            {
                entity.HasKey(e => e.ItemAmountId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoice_item_amounts");

                entity.HasIndex(e => e.ItemId)
                    .HasName("item_id");

                entity.Property(e => e.ItemAmountId)
                    .HasColumnName("item_amount_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemDiscount)
                    .HasColumnName("item_discount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemSubtotal)
                    .HasColumnName("item_subtotal")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemTaxTotal)
                    .HasColumnName("item_tax_total")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemTotal)
                    .HasColumnName("item_total")
                    .HasColumnType("decimal(20,2)");
            });

            modelBuilder.Entity<IpInvoiceItems>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoice_items");

                entity.HasIndex(e => new { e.InvoiceId, e.ItemTaxRateId, e.ItemDateAdded, e.ItemOrder })
                    .HasName("invoice_id");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemDate)
                    .HasColumnName("item_date")
                    .HasColumnType("date");

                entity.Property(e => e.ItemDateAdded)
                    .HasColumnName("item_date_added")
                    .HasColumnType("date");

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("item_description")
                    .HasColumnType("longtext");

                entity.Property(e => e.ItemDiscountAmount)
                    .HasColumnName("item_discount_amount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemIsRecurring)
                    .HasColumnName("item_is_recurring")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ItemName).HasColumnName("item_name");

                entity.Property(e => e.ItemOrder)
                    .HasColumnName("item_order")
                    .HasColumnType("int(2)");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("item_price")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemProductId)
                    .HasColumnName("item_product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemProductUnit)
                    .HasColumnName("item_product_unit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemProductUnitId)
                    .HasColumnName("item_product_unit_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemQuantity)
                    .HasColumnName("item_quantity")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ItemTaskId)
                    .HasColumnName("item_task_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemTaxRateId)
                    .HasColumnName("item_tax_rate_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpInvoiceSumex>(entity =>
            {
                entity.HasKey(e => e.SumexId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoice_sumex");

                entity.Property(e => e.SumexId)
                    .HasColumnName("sumex_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SumexCasedate)
                    .HasColumnName("sumex_casedate")
                    .HasColumnType("date");

                entity.Property(e => e.SumexCasenumber)
                    .HasColumnName("sumex_casenumber")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SumexDiagnosis)
                    .IsRequired()
                    .HasColumnName("sumex_diagnosis")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SumexInvoice)
                    .HasColumnName("sumex_invoice")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SumexObservations)
                    .IsRequired()
                    .HasColumnName("sumex_observations")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SumexReason)
                    .HasColumnName("sumex_reason")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SumexTreatmentend)
                    .HasColumnName("sumex_treatmentend")
                    .HasColumnType("date");

                entity.Property(e => e.SumexTreatmentstart)
                    .HasColumnName("sumex_treatmentstart")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<IpInvoiceTaxRates>(entity =>
            {
                entity.HasKey(e => e.InvoiceTaxRateId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoice_tax_rates");

                entity.HasIndex(e => new { e.InvoiceId, e.TaxRateId })
                    .HasName("invoice_id");

                entity.Property(e => e.InvoiceTaxRateId)
                    .HasColumnName("invoice_tax_rate_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IncludeItemTax)
                    .HasColumnName("include_item_tax")
                    .HasColumnType("int(1)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceTaxRateAmount)
                    .HasColumnName("invoice_tax_rate_amount")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TaxRateId)
                    .HasColumnName("tax_rate_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpInvoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoices");

                entity.HasIndex(e => e.InvoiceStatusId)
                    .HasName("invoice_status_id");

                entity.HasIndex(e => e.InvoiceUrlKey)
                    .HasName("invoice_url_key")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.ClientId, e.InvoiceGroupId, e.InvoiceDateCreated, e.InvoiceDateDue, e.InvoiceNumber })
                    .HasName("user_id");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreditinvoiceParentId)
                    .HasColumnName("creditinvoice_parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceDateCreated)
                    .HasColumnName("invoice_date_created")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceDateDue)
                    .HasColumnName("invoice_date_due")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceDateModified).HasColumnName("invoice_date_modified");

                entity.Property(e => e.InvoiceDiscountAmount)
                    .HasColumnName("invoice_discount_amount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.InvoiceDiscountPercent)
                    .HasColumnName("invoice_discount_percent")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.InvoiceGroupId)
                    .HasColumnName("invoice_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceNumber)
                    .HasColumnName("invoice_number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InvoicePassword)
                    .HasColumnName("invoice_password")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceStatusId)
                    .HasColumnName("invoice_status_id")
                    .HasColumnType("tinyint(2)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.InvoiceTerms)
                    .IsRequired()
                    .HasColumnName("invoice_terms")
                    .HasColumnType("longtext");

                entity.Property(e => e.InvoiceTimeCreated)
                    .HasColumnName("invoice_time_created")
                    .HasDefaultValueSql("'00:00:00'");

                entity.Property(e => e.InvoiceUrlKey)
                    .IsRequired()
                    .HasColumnName("invoice_url_key")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.IsReadOnly)
                    .HasColumnName("is_read_only")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpInvoicesRecurring>(entity =>
            {
                entity.HasKey(e => e.InvoiceRecurringId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_invoices_recurring");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.Property(e => e.InvoiceRecurringId)
                    .HasColumnName("invoice_recurring_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RecurEndDate)
                    .HasColumnName("recur_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.RecurFrequency)
                    .IsRequired()
                    .HasColumnName("recur_frequency")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecurNextDate)
                    .HasColumnName("recur_next_date")
                    .HasColumnType("date");

                entity.Property(e => e.RecurStartDate)
                    .HasColumnName("recur_start_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<IpItemLookups>(entity =>
            {
                entity.HasKey(e => e.ItemLookupId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_item_lookups");

                entity.Property(e => e.ItemLookupId)
                    .HasColumnName("item_lookup_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnName("item_description")
                    .HasColumnType("longtext");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("item_price")
                    .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<IpMerchantResponses>(entity =>
            {
                entity.HasKey(e => e.MerchantResponseId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_merchant_responses");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.HasIndex(e => e.MerchantResponseDate)
                    .HasName("merchant_response_date");

                entity.Property(e => e.MerchantResponseId)
                    .HasColumnName("merchant_response_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MerchantResponse)
                    .IsRequired()
                    .HasColumnName("merchant_response")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantResponseDate)
                    .HasColumnName("merchant_response_date")
                    .HasColumnType("date");

                entity.Property(e => e.MerchantResponseDriver)
                    .IsRequired()
                    .HasColumnName("merchant_response_driver")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantResponseReference)
                    .IsRequired()
                    .HasColumnName("merchant_response_reference")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantResponseSuccessful)
                    .HasColumnName("merchant_response_successful")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<IpPaymentCustom>(entity =>
            {
                entity.HasKey(e => e.PaymentCustomId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_payment_custom");

                entity.HasIndex(e => new { e.PaymentId, e.PaymentCustomFieldid })
                    .HasName("payment_id")
                    .IsUnique();

                entity.Property(e => e.PaymentCustomId)
                    .HasColumnName("payment_custom_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentCustomFieldid)
                    .HasColumnName("payment_custom_fieldid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentCustomFieldvalue).HasColumnName("payment_custom_fieldvalue");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpPaymentMethods>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_payment_methods");

                entity.Property(e => e.PaymentMethodId)
                    .HasColumnName("payment_method_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentMethodName).HasColumnName("payment_method_name");
            });

            modelBuilder.Entity<IpPayments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_payments");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.HasIndex(e => e.PaymentAmount)
                    .HasName("payment_amount");

                entity.HasIndex(e => e.PaymentMethodId)
                    .HasName("payment_method_id");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnName("payment_amount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentMethodId)
                    .HasColumnName("payment_method_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaymentNote)
                    .IsRequired()
                    .HasColumnName("payment_note")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<IpProducts>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_products");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FamilyId)
                    .HasColumnName("family_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("product_description")
                    .HasColumnType("longtext");

                entity.Property(e => e.ProductName).HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("product_price")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ProductSku).HasColumnName("product_sku");

                entity.Property(e => e.ProductTariff)
                    .HasColumnName("product_tariff")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProviderName).HasColumnName("provider_name");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("purchase_price")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.TaxRateId)
                    .HasColumnName("tax_rate_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unit_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpProjects>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_projects");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProjectName).HasColumnName("project_name");
            });

            modelBuilder.Entity<IpQuoteAmounts>(entity =>
            {
                entity.HasKey(e => e.QuoteAmountId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_quote_amounts");

                entity.HasIndex(e => e.QuoteId)
                    .HasName("quote_id");

                entity.Property(e => e.QuoteAmountId)
                    .HasColumnName("quote_amount_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuoteId)
                    .HasColumnName("quote_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuoteItemSubtotal)
                    .HasColumnName("quote_item_subtotal")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.QuoteItemTaxTotal)
                    .HasColumnName("quote_item_tax_total")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.QuoteTaxTotal)
                    .HasColumnName("quote_tax_total")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.QuoteTotal)
                    .HasColumnName("quote_total")
                    .HasColumnType("decimal(20,2)");
            });

            modelBuilder.Entity<IpQuoteCustom>(entity =>
            {
                entity.HasKey(e => e.QuoteCustomId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_quote_custom");

                entity.HasIndex(e => new { e.QuoteId, e.QuoteCustomFieldid })
                    .HasName("quote_id")
                    .IsUnique();

                entity.Property(e => e.QuoteCustomId)
                    .HasColumnName("quote_custom_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuoteCustomFieldid)
                    .HasColumnName("quote_custom_fieldid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuoteCustomFieldvalue).HasColumnName("quote_custom_fieldvalue");

                entity.Property(e => e.QuoteId)
                    .HasColumnName("quote_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpQuoteItemAmounts>(entity =>
            {
                entity.HasKey(e => e.ItemAmountId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_quote_item_amounts");

                entity.HasIndex(e => e.ItemId)
                    .HasName("item_id");

                entity.Property(e => e.ItemAmountId)
                    .HasColumnName("item_amount_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemDiscount)
                    .HasColumnName("item_discount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemSubtotal)
                    .HasColumnName("item_subtotal")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemTaxTotal)
                    .HasColumnName("item_tax_total")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemTotal)
                    .HasColumnName("item_total")
                    .HasColumnType("decimal(20,2)");
            });

            modelBuilder.Entity<IpQuoteItems>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_quote_items");

                entity.HasIndex(e => e.ItemTaxRateId)
                    .HasName("item_tax_rate_id");

                entity.HasIndex(e => new { e.QuoteId, e.ItemDateAdded, e.ItemOrder })
                    .HasName("quote_id");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemDateAdded)
                    .HasColumnName("item_date_added")
                    .HasColumnType("date");

                entity.Property(e => e.ItemDescription).HasColumnName("item_description");

                entity.Property(e => e.ItemDiscountAmount)
                    .HasColumnName("item_discount_amount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemName).HasColumnName("item_name");

                entity.Property(e => e.ItemOrder)
                    .HasColumnName("item_order")
                    .HasColumnType("int(2)");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("item_price")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemProductId)
                    .HasColumnName("item_product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemProductUnit)
                    .HasColumnName("item_product_unit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemProductUnitId)
                    .HasColumnName("item_product_unit_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemQuantity)
                    .HasColumnName("item_quantity")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.ItemTaxRateId)
                    .HasColumnName("item_tax_rate_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuoteId)
                    .HasColumnName("quote_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpQuoteTaxRates>(entity =>
            {
                entity.HasKey(e => e.QuoteTaxRateId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_quote_tax_rates");

                entity.HasIndex(e => e.QuoteId)
                    .HasName("quote_id");

                entity.HasIndex(e => e.TaxRateId)
                    .HasName("tax_rate_id");

                entity.Property(e => e.QuoteTaxRateId)
                    .HasColumnName("quote_tax_rate_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IncludeItemTax)
                    .HasColumnName("include_item_tax")
                    .HasColumnType("int(1)");

                entity.Property(e => e.QuoteId)
                    .HasColumnName("quote_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuoteTaxRateAmount)
                    .HasColumnName("quote_tax_rate_amount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.TaxRateId)
                    .HasColumnName("tax_rate_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpQuotes>(entity =>
            {
                entity.HasKey(e => e.QuoteId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_quotes");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.HasIndex(e => e.QuoteStatusId)
                    .HasName("quote_status_id");

                entity.HasIndex(e => new { e.UserId, e.ClientId, e.InvoiceGroupId, e.QuoteDateCreated, e.QuoteDateExpires, e.QuoteNumber })
                    .HasName("user_id");

                entity.Property(e => e.QuoteId)
                    .HasColumnName("quote_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceGroupId)
                    .HasColumnName("invoice_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext");

                entity.Property(e => e.QuoteDateCreated)
                    .HasColumnName("quote_date_created")
                    .HasColumnType("date");

                entity.Property(e => e.QuoteDateExpires)
                    .HasColumnName("quote_date_expires")
                    .HasColumnType("date");

                entity.Property(e => e.QuoteDateModified).HasColumnName("quote_date_modified");

                entity.Property(e => e.QuoteDiscountAmount)
                    .HasColumnName("quote_discount_amount")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.QuoteDiscountPercent)
                    .HasColumnName("quote_discount_percent")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.QuoteNumber)
                    .HasColumnName("quote_number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QuotePassword)
                    .HasColumnName("quote_password")
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.QuoteStatusId)
                    .HasColumnName("quote_status_id")
                    .HasColumnType("tinyint(2)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.QuoteUrlKey)
                    .IsRequired()
                    .HasColumnName("quote_url_key")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpSessions>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ip_sessions");

                entity.HasIndex(e => e.Timestamp)
                    .HasName("ip_sessions_timestamp");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("blob");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("id")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ip_address")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<IpSettings>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_settings");

                entity.HasIndex(e => e.SettingKey)
                    .HasName("setting_key");

                entity.Property(e => e.SettingId)
                    .HasColumnName("setting_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SettingKey)
                    .IsRequired()
                    .HasColumnName("setting_key")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasColumnName("setting_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<IpTasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_tasks");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .HasColumnName("task_description")
                    .HasColumnType("longtext");

                entity.Property(e => e.TaskFinishDate)
                    .HasColumnName("task_finish_date")
                    .HasColumnType("date");

                entity.Property(e => e.TaskName).HasColumnName("task_name");

                entity.Property(e => e.TaskPrice)
                    .HasColumnName("task_price")
                    .HasColumnType("decimal(20,2)");

                entity.Property(e => e.TaskStatus)
                    .HasColumnName("task_status")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.TaxRateId)
                    .HasColumnName("tax_rate_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpTaxRates>(entity =>
            {
                entity.HasKey(e => e.TaxRateId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_tax_rates");

                entity.Property(e => e.TaxRateId)
                    .HasColumnName("tax_rate_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TaxRateName).HasColumnName("tax_rate_name");

                entity.Property(e => e.TaxRatePercent)
                    .HasColumnName("tax_rate_percent")
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<IpUnits>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_units");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unit_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unit_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitNamePlrl)
                    .HasColumnName("unit_name_plrl")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IpUploads>(entity =>
            {
                entity.HasKey(e => e.UploadId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_uploads");

                entity.Property(e => e.UploadId)
                    .HasColumnName("upload_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileNameNew)
                    .IsRequired()
                    .HasColumnName("file_name_new")
                    .HasColumnType("longtext");

                entity.Property(e => e.FileNameOriginal)
                    .IsRequired()
                    .HasColumnName("file_name_original")
                    .HasColumnType("longtext");

                entity.Property(e => e.UploadedDate)
                    .HasColumnName("uploaded_date")
                    .HasColumnType("date");

                entity.Property(e => e.UrlKey)
                    .IsRequired()
                    .HasColumnName("url_key")
                    .HasMaxLength(32)
                    .IsFixedLength();
            });

            modelBuilder.Entity<IpUserClients>(entity =>
            {
                entity.HasKey(e => e.UserClientId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_user_clients");

                entity.HasIndex(e => new { e.UserId, e.ClientId })
                    .HasName("user_id");

                entity.Property(e => e.UserClientId)
                    .HasColumnName("user_client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpUserCustom>(entity =>
            {
                entity.HasKey(e => e.UserCustomId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_user_custom");

                entity.HasIndex(e => new { e.UserId, e.UserCustomFieldid })
                    .HasName("user_id")
                    .IsUnique();

                entity.Property(e => e.UserCustomId)
                    .HasColumnName("user_custom_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserCustomFieldid)
                    .HasColumnName("user_custom_fieldid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserCustomFieldvalue).HasColumnName("user_custom_fieldvalue");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<IpUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserActive)
                    .HasColumnName("user_active")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserAddress1).HasColumnName("user_address_1");

                entity.Property(e => e.UserAddress2).HasColumnName("user_address_2");

                entity.Property(e => e.UserAllClients)
                    .HasColumnName("user_all_clients")
                    .HasColumnType("int(1)");

                entity.Property(e => e.UserCity).HasColumnName("user_city");

                entity.Property(e => e.UserCompany).HasColumnName("user_company");

                entity.Property(e => e.UserCountry).HasColumnName("user_country");

                entity.Property(e => e.UserDateCreated).HasColumnName("user_date_created");

                entity.Property(e => e.UserDateModified).HasColumnName("user_date_modified");

                entity.Property(e => e.UserEmail).HasColumnName("user_email");

                entity.Property(e => e.UserFax).HasColumnName("user_fax");

                entity.Property(e => e.UserGln)
                    .HasColumnName("user_gln")
                    .HasColumnType("bigint(13)");

                entity.Property(e => e.UserIban)
                    .HasColumnName("user_iban")
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.UserLanguage)
                    .HasColumnName("user_language")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'system'");

                entity.Property(e => e.UserMobile).HasColumnName("user_mobile");

                entity.Property(e => e.UserName).HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UserPasswordresetToken)
                    .HasColumnName("user_passwordreset_token")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserPhone).HasColumnName("user_phone");

                entity.Property(e => e.UserPsalt).HasColumnName("user_psalt");

                entity.Property(e => e.UserRcc)
                    .HasColumnName("user_rcc")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.UserState).HasColumnName("user_state");

                entity.Property(e => e.UserSubscribernumber)
                    .HasColumnName("user_subscribernumber")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserTaxCode).HasColumnName("user_tax_code");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasColumnType("int(1)");

                entity.Property(e => e.UserVatId).HasColumnName("user_vat_id");

                entity.Property(e => e.UserWeb).HasColumnName("user_web");

                entity.Property(e => e.UserZip).HasColumnName("user_zip");
            });

            modelBuilder.Entity<IpVersions>(entity =>
            {
                entity.HasKey(e => e.VersionId)
                    .HasName("PRIMARY");

                entity.ToTable("ip_versions");

                entity.HasIndex(e => e.VersionDateApplied)
                    .HasName("version_date_applied");

                entity.Property(e => e.VersionId)
                    .HasColumnName("version_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VersionDateApplied)
                    .IsRequired()
                    .HasColumnName("version_date_applied")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.VersionFile)
                    .IsRequired()
                    .HasColumnName("version_file")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.VersionSqlErrors)
                    .HasColumnName("version_sql_errors")
                    .HasColumnType("int(2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
