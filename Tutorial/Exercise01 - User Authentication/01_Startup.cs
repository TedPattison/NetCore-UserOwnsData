    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {

      services.AddMicrosoftWebAppAuthentication(Configuration);

      var mvcBuilder = services.AddControllersWithViews(options => {
        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        options.Filters.Add(new AuthorizeFilter(policy));
      });

      mvcBuilder.AddMicrosoftIdentityUI();

      services.AddRazorPages();
    }

