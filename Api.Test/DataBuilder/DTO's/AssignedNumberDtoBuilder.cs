//using Coink.Microservice.Application.DTO_s.AssignedNumber;

//namespace Api.Test.DataBuilder.DTO_s
//{
//    public class AssignedNumberDtoBuilder
//    {
//        private string _number;
//        private DateTime _creationDateTime;

//        public AssignedNumberDtoBuilder()
//        {
//            _number = "DefaultNumber";
//            _creationDateTime = DateTime.UtcNow;
//        }

//        public ParkingDto Build()
//            => new()
//            {
//                Number = _number,
//                CreationDateTime = _creationDateTime
//            };

//        public AssignedNumberDtoBuilder WithNumber(string number)
//        {
//            _number = number;
//            return this;
//        }

//        public AssignedNumberDtoBuilder WithCreationDateTime(DateTime creationDateTime)
//        {
//            _creationDateTime = creationDateTime;
//            return this;
//        }
//    }
//}
