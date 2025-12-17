//using Coink.Microservice.Domain.Entities.AssignedNumber;

//namespace Domain.Test.DataBuilder.Entity
//{
//    public class AssignedNumberEntityBuilder
//    {
//        private string _number;
//        private Guid _userId;
//        private Guid _productId;
//        private DateTime _creationDateTime;
//        private DateTime? _updateDateTime;

//        public AssignedNumberEntityBuilder()
//        {
//            _number = "00001";
//            _userId = Guid.NewGuid();
//            _productId = Guid.NewGuid();
//            _creationDateTime = DateTime.UtcNow;
//            _updateDateTime = null;
//        }

//        public AssignedNumberEntity Build()
//        {
//            return new AssignedNumberEntity
//            {
//                Number = _number,
//                UserId = _userId,
//                ProductId = _productId,
//                CreationDateTime = _creationDateTime,
//                UpdateDateTime = _updateDateTime
//            };
//        }

//        public AssignedNumberEntityBuilder WithNumber(string number)
//        {
//            _number = number;
//            return this;
//        }

//        public AssignedNumberEntityBuilder WithUserId(Guid userId)
//        {
//            _userId = userId;
//            return this;
//        }

//        public AssignedNumberEntityBuilder WithProductId(Guid productId)
//        {
//            _productId = productId;
//            return this;
//        }

//        public AssignedNumberEntityBuilder WithCreationDateTime(DateTime creationDateTime)
//        {
//            _creationDateTime = creationDateTime;
//            return this;
//        }

//        public AssignedNumberEntityBuilder WithUpdateDateTime(DateTime? updateDateTime)
//        {
//            _updateDateTime = updateDateTime;
//            return this;
//        }
//    }
//}
