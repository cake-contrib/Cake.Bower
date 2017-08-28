
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"BowerCacheSettings",
        content:"BowerCacheSettings",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"BowerLogLevel",
        content:"BowerLogLevel",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"BowerHelpSettings",
        content:"BowerHelpSettings",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"BowerHomeSettings",
        content:"BowerHomeSettings",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"BowerInstallSettings",
        content:"BowerInstallSettings",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"BowerOptions Login",
        content:"BowerOptions Login",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"BowerRunnerSettings",
        content:"BowerRunnerSettings",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"BowerRunnerAliases",
        content:"BowerRunnerAliases",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"BowerRunner",
        content:"BowerRunner",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"BowerInfoSettings",
        content:"BowerInfoSettings",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"BowerOptions List",
        content:"BowerOptions List",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"IBowerRunnerCommands",
        content:"IBowerRunnerCommands",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"BowerLoginSettings",
        content:"BowerLoginSettings",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"BowerLinkSettings",
        content:"BowerLinkSettings",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"BowerOptions",
        content:"BowerOptions",
        description:'',
        tags:''
    });

    a({
        id:15,
        title:"BowerCacheSettings SubCommandTypes",
        content:"BowerCacheSettings SubCommandTypes",
        description:'',
        tags:''
    });

    a({
        id:16,
        title:"BowerPruneSettings",
        content:"BowerPruneSettings",
        description:'',
        tags:''
    });

    a({
        id:17,
        title:"BowerListSettings",
        content:"BowerListSettings",
        description:'',
        tags:''
    });

    a({
        id:18,
        title:"BowerRunnerSettingsExtensions",
        content:"BowerRunnerSettingsExtensions",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerCacheSettings',
        title:"BowerCacheSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerLogLevel',
        title:"BowerLogLevel",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerHelpSettings',
        title:"BowerHelpSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerHomeSettings',
        title:"BowerHomeSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerInstallSettings',
        title:"BowerInstallSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/Login',
        title:"BowerOptions.Login",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerRunnerSettings',
        title:"BowerRunnerSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerRunnerAliases',
        title:"BowerRunnerAliases",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerRunner',
        title:"BowerRunner",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerInfoSettings',
        title:"BowerInfoSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/List',
        title:"BowerOptions.List",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/IBowerRunnerCommands',
        title:"IBowerRunnerCommands",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerLoginSettings',
        title:"BowerLoginSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerLinkSettings',
        title:"BowerLinkSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerOptions',
        title:"BowerOptions",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/SubCommandTypes',
        title:"BowerCacheSettings.SubCommandTypes",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerPruneSettings',
        title:"BowerPruneSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerListSettings',
        title:"BowerListSettings",
        description:""
    });

    y({
        url:'/Cake.Bower/Cake.Bower/api/Cake.Bower/BowerRunnerSettingsExtensions',
        title:"BowerRunnerSettingsExtensions",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
