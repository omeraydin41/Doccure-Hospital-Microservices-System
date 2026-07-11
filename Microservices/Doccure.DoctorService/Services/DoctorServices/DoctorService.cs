using AutoMapper;
using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Entities;
using Doccure.DoctorService.Settings;
using MongoDB.Driver;

namespace Doccure.DoctorService.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IMongoCollection<Doctor> _doctorCollection;
        private readonly IMapper _mapper;

        public DoctorService(IDatabaseSettings _settings,IMapper mapper)
        {
            var client = new MongoClient(_settings.ConnectionString);//bağlantı addresi alındı 
            var database = client.GetDatabase(_settings.DatabaseName); //bağlantı addresi uzerınden db ismi alındı 
            _doctorCollection = database.GetCollection<Doctor>(_settings.DoctorCollectionName); //alınaan değerler ile collection oluşturuldu
            _mapper = mapper;//dıştakı mapper ile içerdeki eşlendi 
        }

        public async Task CreateAsync(CreateDoctorDto dto)
        {
          var entity= _mapper.Map<Doctor>(dto);
          await _doctorCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _doctorCollection.DeleteOneAsync(x => x.DoctorId == id);
        }

        public async Task<List<ResultDoctorDto>> GetAllAsync()
        {
            var values = await _doctorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDoctorDto>>(values);
        }

        public async Task<GetByIdDoctorDto> GetByIdAsync(string id)
        {
            var values = await _doctorCollection.Find(x=>x.DoctorId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDoctorDto>(values);
        }

        public async Task UpdateAsync(UpdateDoctorDto dto)
        {
          var entity = _mapper.Map<Doctor>(dto);
            await _doctorCollection.ReplaceOneAsync(x => x.DoctorId == entity.DoctorId, entity);
        }
    }
}
