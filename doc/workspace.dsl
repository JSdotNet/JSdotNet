// https://c4model.com/
// https://structurizr.com/


workspace {
    !identifiers hierarchical

    model {
        reader = person "Readers"
        owner = person "Owner"
        
        auth = softwaresystem "Authentication" {
            //technology "Auth2"
            tags "external" "security" "Azure" "admin" 
		}        

        softwareSystem = softwareSystem "JSdotNet" {
            
            aspire = container "Development Dashboard" {
                technology ".Net Aspire"
                tags "doc" "dev"               
            }

            
            structurizr = container "Documentation" {
                technology "Structurizr"
                tags "doc"                
            }

            monitoring = container "Monitoring" {
                technology "Application Insights"
                tags "external" "admin" 
            }
            cache = container "Cache" {
                technology "Redis"
                tags "external" "admin" 
            }
            // TODO Second databse?
            database = container "Database" {
                technology "SQL"
                tags "database" "admin" 
            }
            
            webApi = container "API" {
                technology "App Service"
                //tags "site"

                group "Presentation" {
                    api = component "API" {
                        technology "ASP.NET"					
    				}
                   
                    endpoints = component "API.Endpoints" {
                        technology "Minimal API"					
    		        }
    		        
    		        api -> endpoints "includes"
               }
               group "Core" {
                    // TODO !include core.dsl
                    application = component "Application" {
                
                    }
                    
                    domain = component "Domain" {
                   
                    }
                }
                
                group "Infrastructure" {
                    // TODO !include infrastructure.dsl
                    ef = component "EF" {
                       technology "Entity Framework"    
                    }
                }

                api -> monitoring "logs to"
                api -> ef "registeres"
                endpoints -> application "depends on"
                application -> domain "depends on"
                application -> ef "ofloads to"
                ef -> application "uses"
                ef -> domain "implements external conserns for"
                ef -> database "read from"
            }
            webapp = container "JSdotNet" {
                technology "Static web app"
                tags "public" //"site"

                group "Presentation" {
                    web = component "Web" {
                        technology "Blazor"					
    				}
                   
                    web_experience = component "Web.Experience" {
                        technology "Blazor components"					
    		        }
    		        web_statistics = component "Web.Statistics" {
                        technology "Blazor components"					
    		        }
    		        web_blog = component "Web.Blog" {
                        technology "Blazor components"					
    		        }
    		        web_architecture = component "Web.Architecture" {
                        technology "Blazor components"					
    		        }
    		        
    		        web -> monitoring "logs to"
    		        web -> web_experience "includes"
    		        web -> web_statistics "includes"
    		        web -> web_blog "includes"
    		        web -> web_architecture "includes"
    		        
    		        web_experience -> webApi.api "requests from"
    		        web_statistics -> monitoring "requests from"
    		        // TODO ??? web_blog -> webApi "uses"
    		        web_architecture -> structurizr "embeds"
               }
            }
            adminapp = container "JSdotNet Admin App" {
                technology "App Service"
                tags "SSR" "public" "admin"

                group "Presentation" {
                    web = component "WEB" {
                        technology "Blazor"					
    				}
                   
                    web_admin = component "Web.Admin" {
                        technology "Blazor components"					
    		        }
    		        
    		        web -> web_admin "includes"
               }
               group "Core" {
                    // TODO !include core.dsl
                    application = component "Application" {
                
                    }
                    
                    domain = component "Domain" {
                   
                    }
                }
                
                group "Infrastructure" {
                    // TODO !include infrastructure.dsl
                    ef = component "EF" {
                       technology "Entity Framework"    
                    }
                }

                web -> monitoring "logs to"
                web -> ef "registeres"
                web_admin -> application "depends on"
                application -> domain "depends on"
                application -> ef "ofloads to"
                ef -> application "uses"
                ef -> domain "implements external conserns for"
                ef -> database "read from and writes to"
            }
            

            reader -> webapp.web "use"
            owner -> adminapp.web "maintains content through"
            
            //webapp -> webApi "Uses"

            //webapp -> monitoring "logs to"
            //adminapp -> monitoring "logs to"
            //webApi -> monitoring "logs to" 

            webapp -> cache "Uses"
            webapp -> cache "Subscribes"
            adminapp -> cache "Publishes"
            
            webapp -> auth "uses authentication servive"
            adminapp -> auth "uses authentication servive"
        }
        
        
        deploymentEnvironment "Development" {
            deploymentNode "Developer Laptop" "" "Microsoft Windows 11" {
                deploymentNode "Web Browser" "" "Chrome, Firefox, Safari, or Edge" {
                    developerDashboardInstance = containerInstance softwareSystem.aspire
                }               
                deploymentNode "local" "" "Visual Studio" {
                    developerWebAppInstance = containerInstance softwareSystem.webapp
                    developerAdminAppInstance = containerInstance softwareSystem.adminapp
                    developerApiApplicationInstance = containerInstance softwareSystem.webApi
                }
                deploymentNode "Docker Desktop" "" "" {
                    deploymentNode "Docker Container - Database Server" "" "Docker" {
                        deploymentNode "Database Server" "" "SQL" {
                            developerDatabaseInstance = containerInstance softwareSystem.database
                        }
                    }
                    deploymentNode "Docker Container - Cache" "" "Docker" {
                        deploymentNode "Redis" "" "Redis" {
                            developerRedisInstance = containerInstance softwareSystem.cache
                        }
                    }
                    deploymentNode "Docker Container - Struturizr" "" "Docker" {
                        deploymentNode "Structurizr lite" "" "Java" {
                            developerStructurizrInstance = containerInstance softwareSystem.structurizr
                        }
                    }
                }
            }
            deploymentNode "SdotNet.Development" "" "Azure Resource Group" {
                 containerInstance softwareSystem.monitoring
            }
        }


        deploymentEnvironment "Production" {
        
            deploymentNode "JSdotNet.Production" "" "Azure Resource Group" {
                // TODO ...
                
                containerInstance softwareSystem.monitoring
            }
            
        }
    }

    views {
        systemContext softwareSystem {
            include *
            autolayout lr
            description "Level 1: A System Context diagram provides a starting point, showing how the software system in scope fits into the world around it."
        }

        container softwareSystem "JSdotNet" {
            include *
            exclude softwareSystem.aspire
            autolayout lr
            description "Level 2: A Container diagram zooms into the software system in scope, showing the high-level technical building blocks."
        }
        //filtered "JSdotNet" include * "All" 
        //filtered "JSdotNet" exclude "admin" "JSdotNet_Public"
        //filtered "JSdotNet" include "admin" "JSdotNet_Admin"

        component softwareSystem.webApi "ComponentsApi" {
            include *
            autoLayout
            description "Level 3: A Component diagram zooms into an individual container, showing the components inside it."
        }

        component softwareSystem.webapp "ComponentsReaderApp" {
            include *
            autoLayout
            description "Level 3: A Component diagram zooms into an individual container, showing the components inside it."
        }
        
        component softwareSystem.adminapp "ComponentsAdminApp" {
            include *
            autoLayout
            description "Level 3: A Component diagram zooms into an individual container, showing the components inside it."
        }


        //image mainframeBankingSystemFacade "MainframeBankingSystemFacade" {
        //    image https://raw.githubusercontent.com/structurizr/examples/main/dsl/big-bank-plc/internet-banking-system/mainframe-banking-system-facade.png
        //    title "[Code] Mainframe Banking System Facade"
        //}

        // TODO Include outbox
        dynamic softwareSystem "Caching" "Summarises Publish subscibe through cache works" {
            softwareSystem.adminapp -> softwareSystem.database "Update some data"
            softwareSystem.adminapp -> softwareSystem.cache "Publishes to"
            softwareSystem.webapp -> softwareSystem.cache "Subscribed to"
            softwareSystem.webapp -> softwareSystem.webApi "Fetch more data"
            softwareSystem.webApi -> softwareSystem.database "reads from"
            softwareSystem.database -> softwareSystem.webApi "result"
            softwareSystem.webApi -> softwareSystem.webapp "response"
            autoLayout
            
            description "Summarises the publish subscribe through Redis cache."
        }

        deployment softwareSystem "Development" "DevelopmentDeployment" {
            include *
            //animation {
            //    softwareSystem.deploymentEnvironment.developerDatabaseInstance softwareSystem.deploymentEnvironment.developerRedisInstance softwareSystem.deploymentEnvironment.developerStructurizrInstance
                //developerWebAppInstance  developerAdminAppInstance developerApiApplicationInstance
                //developerDatabaseInstance
            //}
            autoLayout
            description "Deployment for local development"
        }

        deployment softwareSystem "Production" "ProductionDeployment" {
            include *
            //animation {
            //    developerSinglePageApplicationInstance
            //    developerWebApplicationInstance developerApiApplicationInstance
            //    developerDatabaseInstance
            //}
            autoLayout
            description "Deployment on Azure"
        }

        theme default
        
        styles {
            element "Person" {
                background #4D7887
                color #ffffff
                fontSize 22
                shape Person
            }
            element "Software System" {
                background #C19F44
                color #ffffff
            }

            //TODO filtered "Software System" include "Element,Relationship" [key] [description]
            
            element "Container" {
                background #C19F44
                color #ffffff
            }
            element "database" {
                background #4D7887
                shape Cylinder
            }
            
            element "Component" {
                background #D04E3F
                color #ffffff
            }
            // TODO Focus on entry points
            element "public" {
                fontSize 22
            }
            element "external" {
                background #C2B39E
                color #ffffff
            }
            element "doc" {
                background #C2B39E
                color #ffffff
            }

            // TODO technology icons
            element "sql" {
				background red				
                //icon 
			}
            element "appinsights" {
				background red				
                //icon 
			}
            
            element "Failover" {
                opacity 25
            }
        }

        // TODO ...
        //branding {
        //    logo <file|url>
        //    font <name> [url]
        //}
    }
}