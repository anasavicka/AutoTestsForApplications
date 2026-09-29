namespace ApiTests.DTO.PetStoreDTO
{
    public record MedicalInfoDTO(
        bool Vaccinated,
        bool SpayedNeutered,
        bool Microchipped,
        bool SpecialNeeds,
        string HealthNotes
    );
}