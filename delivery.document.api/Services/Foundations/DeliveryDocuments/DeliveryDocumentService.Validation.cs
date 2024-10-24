using delivery.document.api.Models.DeliveryDocuments.Exceptions;
using delivery.document.api.Models.DeliveryDocuments;


namespace delivery.document.api.Services.Foundations.DeliveryDocuments
{
    public partial class DeliveryDocumentService
    {
        private void ValidateDeliveryDocumentOnCreate(DeliveryDocument deliveryDocument)
        {
            ValidateDeliveryDocumentIsNull(deliveryDocument);

            Validate(
                (rule: IsInvalid(deliveryDocument.DeliveryDocumentID), parameter: nameof(DeliveryDocument.DeliveryDocumentID)),
                (rule: IsInvalid(deliveryDocument.ShipmentID), parameter: nameof(DeliveryDocument.ShipmentID)),
                (rule: IsInvalid(deliveryDocument.DocumentType), parameter: nameof(DeliveryDocument.DocumentType)),
                (rule: IsInvalid(deliveryDocument.CreatedAt), parameter: nameof(DeliveryDocument.CreatedAt)),
                (rule: IsInvalid(deliveryDocument.UpdatedAt), parameter: nameof(DeliveryDocument.UpdatedAt))
            );
        }

        private void ValidateDeliveryDocumentOnModify(DeliveryDocument deliveryDocument)
        {
            ValidateDeliveryDocumentIsNull(deliveryDocument);

            Validate(
                (rule: IsInvalid(deliveryDocument.DeliveryDocumentID), parameter: nameof(DeliveryDocument.DeliveryDocumentID)),
                (rule: IsInvalid(deliveryDocument.ShipmentID), parameter: nameof(DeliveryDocument.ShipmentID)),
                (rule: IsInvalid(deliveryDocument.DocumentType), parameter: nameof(DeliveryDocument.DocumentType)),
                (rule: IsFirstLetterNotCapital(deliveryDocument.DocumentType), parameter: nameof(DeliveryDocument.DocumentType)),
                (rule: IsInvalid(deliveryDocument.CreatedAt), parameter: nameof(DeliveryDocument.CreatedAt)),
                (rule: IsInvalid(deliveryDocument.UpdatedAt), parameter: nameof(DeliveryDocument.UpdatedAt)),
                (rule: IsSame(deliveryDocument.CreatedAt, deliveryDocument.UpdatedAt, nameof(DeliveryDocument.UpdatedAt)), parameter: nameof(DeliveryDocument.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageDeliveryDocumentOnModify(
            DeliveryDocument inputDeliveryDocument, DeliveryDocument storageDeliveryDocument)
        {
            Validate(
                (rule: IsNotSame(inputDeliveryDocument.DeliveryDocumentID, storageDeliveryDocument.DeliveryDocumentID, nameof(DeliveryDocument.DeliveryDocumentID)),
                parameter: nameof(DeliveryDocument.DeliveryDocumentID)),

                (rule: IsNotSame(inputDeliveryDocument.CreatedAt, storageDeliveryDocument.CreatedAt, nameof(DeliveryDocument.CreatedAt)),
                parameter: nameof(DeliveryDocument.CreatedAt)),

                (rule: IsSame(inputDeliveryDocument.UpdatedAt, storageDeliveryDocument.UpdatedAt, nameof(DeliveryDocument.UpdatedAt)),
                parameter: nameof(DeliveryDocument.UpdatedAt))
            );
        }


        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "ID is required."
        };

        private static dynamic IsFirstLetterNotCapital(string text) => new
        {
            Condition = !char.IsUpper(text[0]),
            Message = "The first letter must be capitalized."
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text) || text.Length > 100,
            Message = "Text must not exceed 100 characters and cannot be null or whitespace."
        };

        private static dynamic IsInvalid(DateTime date) => new
        {
            Condition = date == default,
            Message = "Date is required."
        };

        private static dynamic IsSame(DateTime firstDate, DateTime secondDate, string secondDateName) => new
        {
            Condition = Math.Abs((firstDate - secondDate).TotalSeconds) <= 1,
            Message = $"Date matches with {secondDateName}."
        };

        private static dynamic IsNotSame(Guid firstId, Guid secondId, string secondIdName) => new
        {
            Condition = firstId != secondId,
            Message = $"{secondIdName} does not match."
        };

        private static dynamic IsNotSame(DateTime firstDate, DateTime secondDate, string secondDateName) => new
        {
            Condition = Math.Abs((firstDate - secondDate).TotalSeconds) >= 1,
            Message = $"Date does not match with {secondDateName}."
        };


        private static void ValidateDeliveryDocumentIsNull(DeliveryDocument deliveryDocument)
        {
            if (deliveryDocument == null)
            {
                throw new NullDeliveryDocumentException();
            }
        }

        private static void ValidateDeliveryDocumentId(Guid deliveryDocumentID)
        {
            if (deliveryDocumentID == Guid.Empty)
            {
                throw new InvalidDeliveryDocumentException(nameof(DeliveryDocument.DeliveryDocumentID), deliveryDocumentID);
            }
        }

        private static void ValidateStorageDeliveryDocument(DeliveryDocument storageDeliveryDocument, Guid deliveryDocumentID)
        {
            if (storageDeliveryDocument is null) throw new NotFoundDeliveryDocumentException(deliveryDocumentID);
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidDeliveryDocumentException = new InvalidDeliveryDocumentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidDeliveryDocumentException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidDeliveryDocumentException.ThrowIfContainsErrors();
        }
    }

}
