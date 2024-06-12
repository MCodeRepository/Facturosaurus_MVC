$(document).ready(function () {

    let invoiceToCorrection;
    let paymentTypes = null;
    let unitTypes = null;
    let taxTypes = null;


    // Inicialize PaymentTypes to select
    
    if (paymentTypes == null) {
        fetchDataForSelect('/PaymentTypes').then(data => {
            paymentTypes = data;
            updateSelectPaymentType(paymentTypes);
        }).catch(error => {
            console.error(error);
        });
    } else {
        updateSelectPaymentType(paymentTypes);
    }
    

    function updateSelectPaymentType(paymentTypes) {
        $('#paymentTypesCorrection').empty();
        paymentTypes.forEach(function (paymentType) {
            var $option = $('<option>').attr('value', paymentType.id).text(paymentType.name);
            $('#paymentTypesCorrection').append($option);
        });
    }

    // Inicialize UnitTypes to select
        
    if (unitTypes == null) {
        fetchDataForSelect('/UnitTypes/GetActiveUnitTypes').then(data => {
            unitTypes = data;
        }).catch(error => {
            console.error(error);
        });
    } else {
        console.error(error);
    }
        
    

    // Inicialize TaxTypes to select
    
    if (taxTypes == null) {
        fetchDataForSelect('/TaxTypes/GetActiveTaxTypes').then(data => {
            taxTypes = data;
        }).catch(error => {
            console.error(error);
        });
    } else {
        console.error(error);
    }
      
    
    async function fetchDataForSelect(url) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                type: 'GET',
                success: function (data) {
                    resolve(data);
                },
                error: function (xhr, status, error) {
                    reject(xhr.responseText);
                }
            });
        });
    }


    // Actions for ExecutionDate, PaymentType 
    
    $('#executionDateInputCorrection').change(function () {
        updatePaymentDate();
        updateCompanyDetails($(this).val());
    });

    $('#paymentTypesCorrection').change(function () {
        var choosenId = parseInt($(this).val());

        setPaymentDetails(choosenId);
        updatePaymentDate();
    });

    function setPaymentDetails(paymentId) {
        var paymentDetails = paymentTypes.find(p => p.id == paymentId);
        var daysToAdd = paymentDetails.daysToAddToDatePayment;

        $('#CreateNewCorrectionInvoiceModal input[name="PaymentTypeId"]').val(paymentId);
        $('#CreateNewCorrectionInvoiceModal input[name="DaysToAddToDatePayment"]').val(daysToAdd);
    }

    function updatePaymentDate() {
        var executionDate = $('#CreateNewCorrectionInvoiceModal input[name="ExecutionDate"]').val();
        var daysToAdd = $('#CreateNewCorrectionInvoiceModal input[name="DaysToAddToDatePayment"]').val();

        var executionDateObj = new Date(executionDate);
        executionDateObj.setDate(executionDateObj.getDate() + parseInt(daysToAdd));

        var year = executionDateObj.getFullYear();
        var month = String(executionDateObj.getMonth() + 1).padStart(2, '0');
        var day = String(executionDateObj.getDate()).padStart(2, '0');
        var formattedPaymentDate = year + '-' + month + '-' + day;

        $('#CreateNewCorrectionInvoiceModal input[name="PaymentDate"]').val(formattedPaymentDate);
    }
    

    function getFormatedDate(date) {

        var executionDateObj = new Date(date);

        var year = executionDateObj.getFullYear();
        var month = String(executionDateObj.getMonth() + 1).padStart(2, '0');
        var day = String(executionDateObj.getDate()).padStart(2, '0');
        var formattedDate = year + '-' + month + '-' + day;

        return formattedDate;
    }

    $('.correctionButton').click(function () {

        var invoiceId = $(this).data('invoice-id');

        $.ajax({
            url: '/Invoices/' + invoiceId,
            type: 'GET',
            data: { id: invoiceId },
            success: function (result) {

                invoiceToCorrection = result;

                $('#CreateNewCorrectionInvoiceModal input[name="CustomerNipNumber"]').val(result.customerNipNumber);
                $('#CreateNewCorrectionInvoiceModal input[name="CustomerName"]').val(result.customerName);
                $('#CreateNewCorrectionInvoiceModal input[name="CustomerStreetName"]').val(result.customerStreetName);
                $('#CreateNewCorrectionInvoiceModal input[name="CustomerBildingNumber"]').val(result.customerBildingNumber);
                $('#CreateNewCorrectionInvoiceModal input[name="CustomerApartmentNumber"]').val(result.customerApartmentNumber);
                $('#CreateNewCorrectionInvoiceModal input[name="CustomerZipCode"]').val(result.customerZipCode);
                $('#CreateNewCorrectionInvoiceModal input[name="CustomerCity"]').val(result.customerCity);
                $('#CreateNewCorrectionInvoiceModal input[name="PaymentTypeId"]').val(result.paymentTypeId);
                $('#CreateNewCorrectionInvoiceModal input[name="DaysToAddToDatePayment"]').val(result.daysToAddToDatePayment);
                $('#CreateNewCorrectionInvoiceModal input[name="ExecutionDate"]').val(getFormatedDate(result.executionDate));
                $('#CreateNewCorrectionInvoiceModal select[name="PaymentTypeName"]').val(result.paymentTypeId);
                $('#CreateNewCorrectionInvoiceModal input[name="PaymentDate"]').val(getFormatedDate(result.paymentDate));
                $('#CreateNewCorrectionInvoiceModal input[name="CorrectionReason"]').val(result.correctionReason);
                $('#CreateNewCorrectionInvoiceModal input[name="CustomerId"]').val(result.customerId);
                $('#CreateNewCorrectionInvoiceModal input[name="Author"]').val(result.author);
                $('#CreateNewCorrectionInvoiceModal input[name="PaidDate"]').val(getFormatedDate(result.paidDate));
                $('#CreateNewCorrectionInvoiceModal input[name="Paid"]').val(result.paid);
                $('#CreateNewCorrectionInvoiceModal input[name="CompanyDetailsId"]').val(result.companyDetailsId);
                $('#CreateNewCorrectionInvoiceModal input[name="CorrectionId"]').val(result.correctionId);

                createInvoiceItemRows(result.items)
            },
            error: function (xhr, status, error) {

                console.error(xhr.responseText);
            }
        });
    });

    function createInvoiceItemRows(invoiceItems) {
        const container = document.getElementById('items-container-correction');

        container.innerHTML = '';
        unitTypesHtml = '';
        taxTypesHtml = '';

        var itemsSummaryNetValue = 0;
        var itemsSummaryVatValue = 0;
        var itemsSummaryGrossValue = 0;

        unitTypes.forEach(type => {
            const rowOption = `<option value="${type.id}">${type.shortName}</option>`
            unitTypesHtml += rowOption;
        });

        taxTypes.forEach(type => {
            const rowOption = `<option value="${type.id}">${type.name}</option>`
            taxTypesHtml += rowOption;
        });


        invoiceItems.forEach(item => {

            itemsSummaryNetValue += Number(item.netValue);
            itemsSummaryVatValue += Number(item.vatValue);
            itemsSummaryGrossValue += Number(item.grossValue);

            var unitTypeWithSelectedAttributeHtml = unitTypesHtml.replace(`value="${item.unitTypeId}"`, `value="${item.unitTypeId}" selected`);
            var taxTypeWithSelectedAttributeHtml = taxTypesHtml.replace(`value="${item.taxTypeId}"`, `value="${item.taxTypeId}" selected`);

            const rowHtml = `
                    <div class="row mb-2 border-bottom pt-1 pb-1 rowInvoiceItem no-gutters" id="${item.orderNumber}">
                        <div class="row p-0 no-gutters">
                            <div class="col-1 align-content-center col-order">
                                ${item.orderNumber}
                            </div>
                            <div class="col-4 align-content-center col-name itemName">
                                <input class="form-control form-control-sm border-0" value="${item.itemName}" />
                            </div>
                            <div class="col-1 align-content-center col-unit itemUnit">
                                <select class="form-select form-select-sm border-0 unitTypes">
                                    ${unitTypeWithSelectedAttributeHtml}
                                </select>
                            </div>
                            <div class="col-1 align-content-center col-quantity itemQuantity">
                                <input class="form-control form-control-sm border-0" value="${item.quantity}" />
                            </div>
                            <div class="col-1 align-content-center col-price itemPrice">
                                <input class="form-control form-control-sm border-0" value="${item.unitPrice}" />
                            </div>
                            <div class="col-1 align-content-center col-net-value">
                                ${Number(item.netValue).toFixed(2)}
                            </div>
                            <div class="col-1 align-content-center col-tax itemTax">
                                <select class="form-select form-select-sm border-0 taxTypes">
                                   ${taxTypeWithSelectedAttributeHtml}
                                </select>
                            </div>
                            <div class="col-1 align-content-center col-vat-value itemVatValue">
                                ${Number(item.vatValue).toFixed(2)}
                            </div>
                            <div class="col-1 align-content-center col-gross-value itemGrossValue">
                                ${Number(item.grossValue).toFixed(2)}
                            </div>
                        </div>
                    </div>
                `;
            container.innerHTML += rowHtml;
        });

        document.getElementById('itemsSummaryNetValueCorrection').innerHTML = itemsSummaryNetValue.toFixed(2);
        document.getElementById('itemsSummaryVatValueCorrection').innerHTML = itemsSummaryVatValue.toFixed(2);
        document.getElementById('itemsSummaryGrossValueCorrection').innerHTML = itemsSummaryGrossValue.toFixed(2);
    }


    $(document).on('blur', '.itemName input', function () {
        var itemId = $(this).closest('.rowInvoiceItem').attr('id');
        var newValue = $(this).val();

        updateInvoiceItem(itemId, 'itemName', newValue);
    });


    $(document).on('blur', '.itemQuantity input', function () {
        var itemId = $(this).closest('.rowInvoiceItem').attr('id');
        var newValue = $(this).val();

        updateInvoiceItem(itemId, 'quantity', newValue);
    });

    $(document).on('blur', '.itemPrice input', function () {
        var itemId = $(this).closest('.rowInvoiceItem').attr('id');
        var newValue = $(this).val();

        updateInvoiceItem(itemId, 'unitPrice', newValue);
    });

    $(document).on('change', '.itemUnit select', function () {
        var itemId = $(this).closest('.rowInvoiceItem').attr('id');
        var newValue = $(this).val();

        updateInvoiceItem(itemId, 'unitTypeId', newValue);
    });

    $(document).on('change', '.itemTax select', function () {
        var itemId = $(this).closest('.rowInvoiceItem').attr('id');
        var newValue = $(this).val();

        updateInvoiceItem(itemId, 'taxTypeId', newValue);
    });

    function updateInvoiceItem(orderNumber, field, value) {
        let invoiceItems = invoiceToCorrection.items;
        const itemIndex = invoiceItems.findIndex(item => item.orderNumber == orderNumber);
        if (itemIndex !== -1) {
            invoiceItems[itemIndex][field] = value;

            var taxId = invoiceItems[itemIndex]['taxTypeId'];
            var netValue = invoiceItems[itemIndex]['quantity'] * invoiceItems[itemIndex]['unitPrice'];
            var vatType = taxTypes.find(t => t.id == taxId)
            var vatValue = netValue * vatType.rate;
            var grossValue = netValue + vatValue;

            invoiceItems[itemIndex]['netValue'] = netValue.toFixed(2);
            invoiceItems[itemIndex]['vatValue'] = vatValue.toFixed(2);
            invoiceItems[itemIndex]['grossValue'] = grossValue.toFixed(2);

            createInvoiceItemRows(invoiceItems);
        }
    }

    $("#CreateNewCorrectionInvoiceModal form").submit(function (event) {
        event.preventDefault();

        var invoice = new InvoiceDto();

        invoice.documentTypeId = 2;
        invoice.executionDate = $('#CreateNewCorrectionInvoiceModal input[name="ExecutionDate"]').val();
        invoice.paymentTypeId = parseInt($('#CreateNewCorrectionInvoiceModal input[name="PaymentTypeId"]').val());
        invoice.paymentDate = $('#CreateNewCorrectionInvoiceModal input[name="PaymentDate"]').val();

        const netSummaryValue = document.getElementById('itemsSummaryNetValueCorrection').textContent;
        const vatSummaryValue = document.getElementById('itemsSummaryVatValueCorrection').textContent;
        const grossSummaryValue = document.getElementById('itemsSummaryGrossValueCorrection').textContent;

        invoice.netAmount = parseFloat(netSummaryValue);
        invoice.vatAmount = parseFloat(vatSummaryValue);
        invoice.grossAmount = parseFloat(grossSummaryValue);

        if (invoice.executionDate == invoice.paymentDate) {
            invoice.paid = JSON.parse($('#CreateNewCorrectionInvoiceModal input[name="Paid"]').val());
            invoice.paidDate = $('#CreateNewCorrectionInvoiceModal input[name="PaymentDate"]').val();
        }
        else {
            invoice.paid = false;
        }

        invoice.author = "Justyna Trzaska";

        invoice.customerId = parseInt($('#CreateNewCorrectionInvoiceModal input[name="CustomerId"]').val());
        invoice.customerName = $('#CreateNewCorrectionInvoiceModal input[name="CustomerName"]').val();
        invoice.customerNipNumber = $('#CreateNewCorrectionInvoiceModal input[name="CustomerNipNumber"]').val();
        invoice.customerStreetName = $('#CreateNewCorrectionInvoiceModal input[name="CustomerStreetName"]').val();
        invoice.customerBuildingNumber = $('#CreateNewCorrectionInvoiceModal input[name="CustomerBildingNumber"]').val();
        invoice.customerApartmentNumber = $('#CreateNewCorrectionInvoiceModal input[name="CustomerApartmentNumber"]').val();
        invoice.customerZipCode = $('#CreateNewCorrectionInvoiceModal input[name="CustomerZipCode"]').val();
        invoice.customerCity = $('#CreateNewCorrectionInvoiceModal input[name="CustomerCity"]').val();
        invoice.companyDetailsId = parseInt($('#CreateNewCorrectionInvoiceModal input[name="CompanyDetailsId"]').val());
        invoice.correctionReason = $('#CreateNewCorrectionInvoiceModal input[name="CorrectionReason"]').val();
        invoice.correctionId = invoiceToCorrection.id;

        invoice.items = invoiceToCorrection.items;


        $.ajax({
            url: '/Invoices/Correction',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(invoice),
            success: function (data) {
                toastr["success"]("Korekta została utworzona")
                setTimeout(function () {
                    location.reload();
                }, 2000);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                let responseMessage = jqXHR.responseText;
                const regex = /\[\"([^\]]+)\"\]/g;
                const uniquePhrases = new Set();
                let match;

                while ((match = regex.exec(responseMessage)) !== null) {
                    const cleanedPhrase = match[1].replace(/'/g, '');
                    uniquePhrases.add(cleanedPhrase);
                }
                const errorMessage = Array.from(uniquePhrases).join('<br>');

                toastr["error"]("Błąd tworzenia korekty: <br>" + errorMessage);
            }
        })
    });

    class InvoiceDto {
        constructor() {
            // Head
            this.id = 0;
            this.documentTypeId = 0;
            this.documentShortName = "";
            this.documentName = "";
            this.number = 0;
            this.month = 0;
            this.year = 0;
            this.createDate = new Date();
            this.executionDate = new Date();
            this.paymentTypeId = 0;
            this.paymentTypeName = "";
            this.daysToAddToDatePayment = 0;
            this.paymentDate = new Date();
            this.netAmount = 0.0;
            this.grossAmount = 0.0;
            this.vatAmount = 0.0;
            this.paid = false;
            this.paidDate = new Date();
            this.author = "";

            // Customer
            this.customerId = 0;
            this.customerName = "";
            this.customerNipNumber = "";
            this.customerStreetName = "";
            this.customerBuildingNumber = "";
            this.customerApartmentNumber = "";
            this.customerZipCode = "";
            this.customerCity = "";

            // Company details
            this.companyDetailsId = 0;
            this.companyShortName = "";
            this.companyName = "";
            this.companyNipNumber = "";
            this.companyStreetName = "";
            this.companyBuildingNumber = "";
            this.companyApartmentNumber = "";
            this.companyZipCode = "";
            this.companyCity = "";
            this.companyBankName = "";
            this.companyCurrency = "";
            this.companyBankAccountNumber = "";
            this.companyPhoneNumber = "";
            this.companyAddressEmail = "";

            // Correction
            this.correctionId = null;
            this.correctionReason = "";

            // Items
            this.items = [];
        }
    }
});