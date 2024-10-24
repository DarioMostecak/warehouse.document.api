// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Invoices.Exceptions;
using delivery.document.api.Models.Invoices;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.Invoices
{
    public partial class InvoiceService
    {
        private delegate ValueTask<Invoice> ReturnInvoiceFunction();
        private delegate IQueryable<Invoice> ReturningQueryableInvoicesFunction();

        private async ValueTask<Invoice> TryCatch(
            ReturnInvoiceFunction returnInvoiceFunction)
        {
            try
            {
                return await returnInvoiceFunction();
            }
            catch (NullInvoiceException nullInvoiceException)
            {
                throw CreateAndLogValidationException(nullInvoiceException);
            }
            catch (InvalidInvoiceException invalidInvoiceException)
            {
                throw CreateAndLogValidationException(invalidInvoiceException);
            }
            catch (NotFoundInvoiceException notFoundInvoiceException)
            {
                throw CreateAndLogValidationException(notFoundInvoiceException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsInvoiceException =
                    new AlreadyExistsInvoiceException(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsInvoiceException);
            }
            catch (MongoException mongoException)
            {
                var failedInvoiceServiceException =
                    new FailedInvoiceServiceException(mongoException);

                throw CreateAndLogDependencyException(failedInvoiceServiceException);
            }
            catch (Exception exception)
            {
                var failedInvoiceServiceException =
                    new FailedInvoiceServiceException(exception);

                throw CreateAndLogServiceException(failedInvoiceServiceException);
            }
        }

        private IQueryable<Invoice> TryCatch(
            ReturningQueryableInvoicesFunction returningQueryableInvoicesFunction)
        {
            try
            {
                return returningQueryableInvoicesFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedInvoiceServiceException =
                    new FailedInvoiceServiceException(exception);

                throw CreateAndLogServiceException(failedInvoiceServiceException);
            }
        }

        private InvoiceValidationException CreateAndLogValidationException(Exception exception)
        {
            var invoiceValidationException = new InvoiceValidationException(exception, exception.Data);
            this.loggingBroker.LogError(invoiceValidationException);

            return invoiceValidationException;
        }

        private InvoiceDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var invoiceDependencyException = new InvoiceDependencyException(exception);
            this.loggingBroker.LogError(invoiceDependencyException);

            return invoiceDependencyException;
        }

        private InvoiceServiceException CreateAndLogServiceException(Exception exception)
        {
            var invoiceServiceException = new InvoiceServiceException(exception);
            this.loggingBroker.LogError(invoiceServiceException);

            return invoiceServiceException;
        }
    }

}
