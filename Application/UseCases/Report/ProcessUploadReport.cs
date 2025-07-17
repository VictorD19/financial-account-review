using Domain.Entities;
using Application.DTOs;

namespace Application.UseCases{
public class ProcessUploadReport{
    private readonly IReportRepository _repository;
    
    public ProcessUploadReport(IReportRepository repository){
        _repository = repository
    }
    
    public Task<ResultDTO> UploadFile(UploadReportDTO dataUpload){

await _repository.Adicionar(mew Report(){
FileName = "Teste",
SendDate = new Date(),
User= "Victor",
Status = "received"
})
return new ResultDTO(){
 Success = true,
 Message = "Arquivo Salvo com sucesso"   
}
    }

}}