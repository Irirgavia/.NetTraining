namespace WebClient
{
    using AutoMapper;

    using BLEntity;

    using WebClient.Models;

    public class ModelMapper
    {
        private IMapper mapper;

        public ModelMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                    {
                        cfg.CreateMap<ClientDTO, ClientModel>();
                        cfg.CreateMap<ClientModel, ClientDTO>();

                        cfg.CreateMap<CredentialsDTO, CredentialsModel>();
                        cfg.CreateMap<CredentialsModel, CredentialsDTO>();

                        cfg.CreateMap<ProductDTO, string>();
                        cfg.CreateMap<string, ProductDTO>();

                        cfg.CreateMap<RoleDTO, string>();
                        cfg.CreateMap<string, RecordFileDTO>();

                        cfg.CreateMap<SaleDTO, SaleModel>();
                        cfg.CreateMap<SaleModel, SaleDTO>();

                        cfg.CreateMap<UserDTO, UserModel>();
                        cfg.CreateMap<UserModel, UserDTO>();
                    });

            this.mapper = config.CreateMapper();
        }

        public ClientModel ToModel(ClientDTO client)
        {
            return this.mapper.Map<ClientDTO, ClientModel>(client);
        }

        public CredentialsModel ToModel(CredentialsDTO credentials)
        {
            return this.mapper.Map<CredentialsDTO, CredentialsModel>(credentials);
        }

        public string ToModel(ProductDTO product)
        {
            return product.Name;
        }

        public string ToModel(RoleDTO role)
        {
            return role.Name;
        }

        public SaleModel ToModel(SaleDTO sale)
        {
            return this.mapper.Map<SaleDTO, SaleModel>(sale);
        }

        public UserModel ToModel(UserDTO user)
        {
            return this.mapper.Map<UserDTO, UserModel>(user);
        }

        public ClientDTO ToBLO(ClientModel client)
        {
            return this.mapper.Map<ClientModel, ClientDTO>(client);
        }

        public CredentialsDTO ToBLO(CredentialsModel credentials)
        {
            return this.mapper.Map<CredentialsModel, CredentialsDTO>(credentials);
        }

        public SaleDTO ToBLO(SaleModel sale)
        {
            return this.mapper.Map<SaleModel, SaleDTO>(sale);
        }

        public UserDTO ToBLO(UserModel user)
        {
            return this.mapper.Map<UserModel, UserDTO>(user);
        }
    }
}