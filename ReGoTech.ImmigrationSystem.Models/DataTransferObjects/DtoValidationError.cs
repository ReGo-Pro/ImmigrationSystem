namespace ReGoTech.ImmigrationSystem.Models.DataTransferObjects
{
	public class DtoValidationError
	{
        public required string PropertyName { get; set; }
		public required string ErrorMessage { get; set; }
    }
}
