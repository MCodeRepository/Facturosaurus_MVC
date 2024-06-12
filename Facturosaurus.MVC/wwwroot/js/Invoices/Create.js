$(document).ready(function () {

    const invoiceItems = [];

    const $customerNameInput = $('#customerNameInput');
    const $customerNamesList = $('#customerNamesList');
    const $customerNipInput = $('#customerNipInput');
    const $customerNipList = $('#customerNipList');
    const $addItem = $('#add-item');

    var lastIdOfItem = 0;

    let customers = null;
    let paymentTypes = null;
    let unitTypes = null;
    let taxTypes = null;


    // Inicialize DateExecution
    {
        var executionDate = $('#CreateNewInvoiceModal input[name="ExecutionDate"]').val();

        if (executionDate != null) {
            updateCompanyDetails(executionDate);
        }
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

    // Inicialize PaymentTypes to select
    {
        {
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
        }

        function updateSelectPaymentType(paymentTypes) {
            $('#paymentTypes').empty();
            paymentTypes.forEach(function (paymentType) {
                var $option = $('<option>').attr('value', paymentType.id).text(paymentType.name);
                $('#paymentTypes').append($option);
            });

            $('#paymentTypes option:first').attr('selected', 'selected');

            var id = $('#paymentTypes').val();

            setPaymentDetails(id);
            updatePaymentDate();
        }
    }

    // Inicialize UnitTypes to select
    {
        {
            if (unitTypes == null) {
                fetchDataForSelect('/UnitTypes/GetActiveUnitTypes').then(data => {
                    unitTypes = data;
                }).catch(error => {
                    console.error(error);
                });
            } else {
                console.error(error);
            }
        }
    }

    // Inicialize TaxTypes to select
    {
        {
            if (taxTypes == null) {
                fetchDataForSelect('/TaxTypes/GetActiveTaxTypes').then(data => {
                    taxTypes = data;
                }).catch(error => {
                    console.error(error);
                });
            } else {
                console.error(error);
            }
        }
    }


    //Company details

    async function updateCompanyDetails(date) {
        var companyDetails = await feachCompanyDetailsByDate('/CompanyDetails/' + date);

        if (companyDetails != null) {
            $('#CreateNewInvoiceModal input[name="CompanyDetailsId"]').val(companyDetails.id);
        } else {
            console.error(error);
        }
    }

    async function feachCompanyDetailsByDate(url) {
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
    {
        $('#executionDateInput').change(function () {
            updatePaymentDate();
            updateCompanyDetails($(this).val());
        });

        $('#paymentTypes').change(function () {
            var choosenId = parseInt($(this).val());

            setPaymentDetails(choosenId);
            updatePaymentDate();
        });

        function setPaymentDetails(paymentId) {
            var paymentDetails = paymentTypes.find(p => p.id == paymentId);
            var daysToAdd = paymentDetails.daysToAddToDatePayment;

            $('#CreateNewInvoiceModal input[name="PaymentTypeId"]').val(paymentId);
            $('#CreateNewInvoiceModal input[name="DaysToAddToDatePayment"]').val(daysToAdd);
        }

        function updatePaymentDate() {
            var executionDate = $('#CreateNewInvoiceModal input[name="ExecutionDate"]').val();
            var daysToAdd = $('#CreateNewInvoiceModal input[name="DaysToAddToDatePayment"]').val();

            var executionDateObj = new Date(executionDate);
            executionDateObj.setDate(executionDateObj.getDate() + parseInt(daysToAdd));

            var year = executionDateObj.getFullYear();
            var month = String(executionDateObj.getMonth() + 1).padStart(2, '0');
            var day = String(executionDateObj.getDate()).padStart(2, '0');
            var formattedPaymentDate = year + '-' + month + '-' + day;

            $('#CreateNewInvoiceModal input[name="PaymentDate"]').val(formattedPaymentDate);
        }
    }

    // Searching Customer by NIP number or name

    {
        $customerNameInput.on('click', function () {
            $customerNipList.hide();
        });
        $customerNipInput.on('click', function () {
            $customerNamesList.hide();
        });

        $customerNameInput.on('input', async function () {
            clearCustomerDetails(this.name);
            const value = this.value.toLowerCase();

            if (value) {
                if (customers == null) {
                    try {
                        customers = await fetchCustomers('/Customers');
                        updateDatalist(customers, value, $customerNamesList, $customerNameInput, 'customerName');
                    } catch (error) {
                        console.error(error);
                    }
                } else {
                    updateDatalist(customers, value, $customerNamesList, $customerNameInput, 'customerName');
                }
            } else {
                $customerNamesList.hide();
            }
        });

        $customerNipInput.on('input', async function () {
            clearCustomerDetails(this.name);
            const value = this.value.toLowerCase();

            if (value) {
                if (customers == null) {
                    try {
                        customers = await fetchCustomers('/Customers');
                        updateDatalist(customers, value, $customerNipList, $customerNipInput, 'nipNumber');
                    } catch (error) {
                        console.error(error);
                    }
                } else {
                    updateDatalist(customers, value, $customerNipList, $customerNipInput, 'nipNumber');
                }
            } else {
                $customerNipList.hide();
            }
        });

        async function fetchCustomers(url) {
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

        function updateDatalist(customers, value, $datalist, $input, fieldName) {
            $datalist.empty();
            customers.forEach(item => {
                if (item[fieldName].toLowerCase().includes(value)) {
                    const $item = $('<div>')
                        .addClass('datalist-item')
                        .text(item[fieldName])
                        .on('click', function () {
                            $('#CreateNewInvoiceModal input[name="CustomerId"]').val(item.id);
                            $('#CreateNewInvoiceModal input[name="CustomerName"]').val(item.customerName);
                            $('#CreateNewInvoiceModal input[name="CustomerNipNumber"]').val(item.nipNumber);
                            $('#CreateNewInvoiceModal input[name="CustomerStreetName"]').val(item.streetName);
                            $('#CreateNewInvoiceModal input[name="CustomerBildingNumber"]').val(item.bildingNumber);
                            $('#CreateNewInvoiceModal input[name="CustomerApartmentNumber"]').val(item.apartmentNumber);
                            $('#CreateNewInvoiceModal input[name="CustomerZipCode"]').val(item.zipCode);
                            $('#CreateNewInvoiceModal input[name="CustomerCity"]').val(item.city);
                            $datalist.hide();
                        });
                    $datalist.append($item);
                }
            });
            $datalist.toggle($datalist.children().length > 0);
        }

        function clearCustomerDetails(changedFieldName) {
            if (changedFieldName=="CustomerName") {
                $('#CreateNewInvoiceModal input[name="CustomerNipNumber"]').val("");
            }
            if (changedFieldName == "CustomerNipNumber") {
                $('#CreateNewInvoiceModal input[name="CustomerName"]').val("");
            }
            $('#CreateNewInvoiceModal input[name="CustomerId"]').val(0);
            $('#CreateNewInvoiceModal input[name="CustomerStreetName"]').val("");
            $('#CreateNewInvoiceModal input[name="CustomerBildingNumber"]').val("");
            $('#CreateNewInvoiceModal input[name="CustomerApartmentNumber"]').val("");
            $('#CreateNewInvoiceModal input[name="CustomerZipCode"]').val("");
            $('#CreateNewInvoiceModal input[name="CustomerCity"]').val("");
        }
    }


    // Actions for invoice positions
    class InvoiceItemDto {
        constructor(orderNumber, itemName, quantity, unitPrice, netValue, vatValue, grossValue, unitTypeId, taxTypeId, itemId) {
            this.orderNumber = orderNumber;
            this.itemName = itemName || "";
            this.quantity = quantity;
            this.unitPrice = unitPrice;
            this.netValue = netValue;
            this.vatValue = vatValue;
            this.grossValue = grossValue;
            this.unitTypeId = unitTypeId;
            this.taxTypeId = taxTypeId;
            this.itemId = itemId;
        }
    }

    { 
        $addItem.on('click', function () {
            initItem();
        });

        $(document).on('click', '.deleteButton', function () {
            var itemId = $(this).data('item-id');

            const itemIndex = invoiceItems.findIndex(item => item.itemId == itemId);

            if (itemIndex !== -1) {
                invoiceItems.splice(itemIndex, 1);
                renumereteItemsOrder(invoiceItems);
                createInvoiceItemRows(invoiceItems);
            }
        });

        $(document).on('blur', '.col-name input', function () {
            var itemId = $(this).closest('.rowInvoiceItem').attr('id');
            var newValue = $(this).val();

            updateInvoiceItem(itemId, 'itemName', newValue);
        });

        $(document).on('blur', '.col-quantity input', function () {
            var itemId = $(this).closest('.rowInvoiceItem').attr('id');
            var newValue = $(this).val();

            updateInvoiceItem(itemId, 'quantity', newValue);
        });

        $(document).on('blur', '.col-price input', function () {
            var itemId = $(this).closest('.rowInvoiceItem').attr('id');
            var newValue = $(this).val();

            updateInvoiceItem(itemId, 'unitPrice', newValue);
        });

        $(document).on('change', '.col-unit select', function () {
            var itemId = $(this).closest('.rowInvoiceItem').attr('id');
            var newValue = $(this).val();

            updateInvoiceItem(itemId, 'unitTypeId', newValue);
        });

        $(document).on('change', '.col-tax select', function () {
            var itemId = $(this).closest('.rowInvoiceItem').attr('id');
            var newValue = $(this).val();

            updateInvoiceItem(itemId, 'taxTypeId', newValue);
        });

        function renumereteItemsOrder(invoiceItems) {
            var orderNumber = 1
            invoiceItems.forEach(item => {
                item.orderNumber = orderNumber;
                orderNumber += 1;
            });
        }

        function updateInvoiceItem(itemId, field, value) {
            const itemIndex = invoiceItems.findIndex(item =>    item.itemId == itemId);
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
    

        function initItem() {

            lastIdOfItem += 1;
            var idForItem = `item_${lastIdOfItem}`;
            var maxOrderNumber = invoiceItems.length==0 ? 0 : Math.max(...invoiceItems.map(item => item.orderNumber));

            invoiceItems.push(new InvoiceItemDto(maxOrderNumber + 1, "Usługi projektowania graficznego", 1, 0.0, 0.0, 0.0, 0.0, 1, 1, idForItem));

            createInvoiceItemRows(invoiceItems);
        };

        function createInvoiceItemRows(invoiceItems) {
            const container = document.getElementById('items-container');

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
                    <div class="row mb-2 border-bottom pt-1 pb-1 rowInvoiceItem no-gutters" id="${item.itemId}">
                        <div class="row p-0 no-gutters">
                            <div class="col-1 align-content-center col-order">
                                ${item.orderNumber}
                            </div>
                            <div class="col-3 align-content-center col-name">
                                <input class="form-control form-control-sm border-0" value="${item.itemName}" />
                            </div>
                            <div class="col-1 align-content-center col-unit">
                                <select class="form-select form-select-sm border-0 unitTypes">
                                    ${unitTypeWithSelectedAttributeHtml}
                                </select>
                            </div>
                            <div class="col-1 align-content-center col-quantity">
                                <input class="form-control form-control-sm border-0" value="${item.quantity}" />
                            </div>
                            <div class="col-1 align-content-center col-price">
                                <input class="form-control form-control-sm border-0" value="${item.unitPrice}" />
                            </div>
                            <div class="col-1 align-content-center col-net-value">
                                ${Number(item.netValue).toFixed(2)}
                            </div>
                            <div class="col-1 align-content-center col-tax">
                                <select class="form-select form-select-sm border-0 taxTypes">
                                   ${taxTypeWithSelectedAttributeHtml}
                                </select>
                            </div>
                            <div class="col-1 align-content-center col-vat-value">
                                ${Number(item.vatValue).toFixed(2)}
                            </div>
                            <div class="col-1 align-content-center col-gross-value">
                                ${Number(item.grossValue).toFixed(2)}
                            </div>
                            <div class="col-1 align-content-center col-action">
                                <a class="btn btn-sm bi bi-trash item-button deleteButton" data-item-id="${item.itemId}"></a>
                            </div>
                        </div>
                    </div>
                `;
                container.innerHTML += rowHtml;
            });

            document.getElementById('itemsSummaryNetValue').innerHTML = itemsSummaryNetValue.toFixed(2);
            document.getElementById('itemsSummaryVatValue').innerHTML = itemsSummaryVatValue.toFixed(2);
            document.getElementById('itemsSummaryGrossValue').innerHTML = itemsSummaryGrossValue.toFixed(2);
        }
    }


    $("#CreateNewInvoiceModal form").submit(function (event) {
        event.preventDefault();

        var invoice = new InvoiceDto();

        invoice.documentTypeId = 1;
        invoice.executionDate = $('#CreateNewInvoiceModal input[name="ExecutionDate"]').val();
        invoice.paymentTypeId = parseInt($('#CreateNewInvoiceModal input[name="PaymentTypeId"]').val());
        invoice.paymentDate = $('#CreateNewInvoiceModal input[name="PaymentDate"]').val();

        const netSummaryValue = document.getElementById('itemsSummaryNetValue').textContent;
        const vatSummaryValue = document.getElementById('itemsSummaryVatValue').textContent;
        const grossSummaryValue = document.getElementById('itemsSummaryGrossValue').textContent;

        invoice.netAmount = parseFloat(netSummaryValue);
        invoice.vatAmount = parseFloat(vatSummaryValue);
        invoice.grossAmount = parseFloat(grossSummaryValue);

        if (invoice.executionDate == invoice.paymentDate) {
            invoice.paid = JSON.parse($('#CreateNewInvoiceModal input[name="Paid"]').val());
            invoice.paidDate = $('#CreateNewInvoiceModal input[name="PaymentDate"]').val();
        }
        else {
            invoice.paid = false;
        }

        invoice.author = "Justyna Trzaska";

        invoice.customerId = parseInt($('#CreateNewInvoiceModal input[name="CustomerId"]').val());
        invoice.customerName = $('#CreateNewInvoiceModal input[name="CustomerName"]').val();
        invoice.customerNipNumber = $('#CreateNewInvoiceModal input[name="CustomerNipNumber"]').val();
        invoice.customerStreetName = $('#CreateNewInvoiceModal input[name="CustomerStreetName"]').val();
        invoice.customerBuildingNumber = $('#CreateNewInvoiceModal input[name="CustomerBildingNumber"]').val();
        invoice.customerApartmentNumber = $('#CreateNewInvoiceModal input[name="CustomerApartmentNumber"]').val();
        invoice.customerZipCode = $('#CreateNewInvoiceModal input[name="CustomerZipCode"]').val();
        invoice.customerCity = $('#CreateNewInvoiceModal input[name="CustomerCity"]').val();
        invoice.companyDetailsId = parseInt($('#CreateNewInvoiceModal input[name="CompanyDetailsId"]').val());

        invoice.items = invoiceItems;
    

        $.ajax({
            url: '/Invoices',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(invoice),
            success: function (data) {
                toastr["success"]("Faktura została utworzona")
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

                toastr["error"]("Błąd tworzenia faktury: <br>" + errorMessage);
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