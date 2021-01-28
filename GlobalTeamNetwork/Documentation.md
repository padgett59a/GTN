# Adding new entities
1. Add object in Model folder
2. Add IxRepository in Model folder
3. Add xReposiory in Model folder (implement Ix)
4. Register in Startup.ConfigureServices as **services.AddScoped<IxRepository, sRepository>();**
5. Add private property to controller as **private readonly IxRepository _xRepository;**
6. Inject into controller consturcter as **public SaidController(IxRepository xRepository) \{
            _xRepository = xRepository;
        }**
7. Use _x in controller methods
