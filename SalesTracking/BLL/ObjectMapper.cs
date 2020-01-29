namespace BLL
{
    using AutoMapper;

    using BLEntity;

    using DAL.Entity;

    public class ObjectMapper
    {
        private IMapper mapper;

        public ObjectMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<ClientDTO, ClientEntity>();
                        cfg.CreateMap<ClientEntity, ClientDTO>();

                        cfg.CreateMap<CredentialsDTO, CredentialsEntity>();
                        cfg.CreateMap<CredentialsEntity, CredentialsDTO>();

                        cfg.CreateMap<ProductDTO, ProductEntity>();
                        cfg.CreateMap<ProductEntity, ProductDTO>();

                        cfg.CreateMap<RecordFileDTO, RecordFileEntity>();
                        cfg.CreateMap<RecordFileEntity, RecordFileDTO>();

                        cfg.CreateMap<RoleDTO, RoleEntity>();
                        cfg.CreateMap<RoleEntity, RecordFileDTO>();

                        cfg.CreateMap<SaleDTO, SaleEntity>();
                        cfg.CreateMap<SaleEntity, SaleDTO>();

                        cfg.CreateMap<UserDTO, UserEntity>();
                        cfg.CreateMap<UserEntity, UserDTO>();
                    });

            this.mapper = config.CreateMapper();
        }

        public ClientDTO ToBLO(ClientEntity client)
        {
            return this.mapper.Map<ClientEntity, ClientDTO>(client);
        }

        public CredentialsDTO ToBLO(CredentialsEntity credentials)
        {
            return this.mapper.Map<CredentialsEntity, CredentialsDTO>(credentials);
        }

        public ProductDTO ToBLO(ProductEntity product)
        {
            return this.mapper.Map<ProductEntity, ProductDTO>(product);
        }

        public RecordFileDTO ToBLO(RecordFileEntity recordFile)
        {
            return this.mapper.Map<RecordFileEntity, RecordFileDTO>(recordFile);
        }

        public RoleDTO ToBLO(RoleEntity role)
        {
            return this.mapper.Map<RoleEntity, RoleDTO>(role);
        }

        public SaleDTO ToBLO(SaleEntity sale)
        {
            return this.mapper.Map<SaleEntity, SaleDTO>(sale);
        }

        public UserDTO ToBLO(UserEntity user)
        {
            return this.mapper.Map<UserEntity, UserDTO>(user);
        }

        public RecordFileEntity ToDLO(RecordFileDTO recordFile)
        {
            return this.mapper.Map<RecordFileDTO, RecordFileEntity>(recordFile);
        }

        public SaleEntity ToDLO(SaleDTO sale)
        {
            return this.mapper.Map<SaleDTO, SaleEntity>(sale);
        }

        public ClientEntity ToDLO(ClientDTO client)
        {
            return this.mapper.Map<ClientDTO, ClientEntity>(client);
        }

        public CredentialsEntity ToDLO(CredentialsDTO credentials)
        {
            return this.mapper.Map<CredentialsDTO, CredentialsEntity>(credentials);
        }

        public ProductEntity ToDLO(ProductDTO product)
        {
            return this.mapper.Map<ProductDTO, ProductEntity>(product);
        }

        public RoleEntity ToDLO(RoleDTO role)
        {
            return this.mapper.Map<RoleDTO, RoleEntity>(role);
        }

        public UserEntity ToDLO(UserDTO user)
        {
            return this.mapper.Map<UserDTO, UserEntity>(user);
        }
    }
}