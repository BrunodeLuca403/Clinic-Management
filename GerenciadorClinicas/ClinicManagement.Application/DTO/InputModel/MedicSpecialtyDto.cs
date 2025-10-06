namespace ClinicManagement.Application.DTO.InputModel
{
    public record MedicSpecialtyDto(Guid MedicId, Guid SpecialtyId)
    {
        public Guid MedicId { get; private set; } = MedicId;
        public Guid SpecialtyId { get; private set; } = SpecialtyId;
    }
}
