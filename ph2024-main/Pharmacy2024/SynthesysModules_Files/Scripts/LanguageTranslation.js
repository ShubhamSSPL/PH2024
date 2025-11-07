// JScript File

//Crated By Laxman Nagtilak on 15/12/2010. It Uses Transliteration Google ApI ..

    //Transliteration  control  object.
     var transliterationControl;
     
     google.load("elements", "1", {
            packages: "transliteration"
          });


//Callback Function 

      function onLoad() {
       //if new language added in xml then code should be added here in  destination Language
      
        var options = {
            sourceLanguage: 'en',
            destinationLanguage: ['bn','gu','hi', 'kn','ml','mr','pa', 'sa','ta','te','ur'],

            transliterationEnabled: true,
            shortcutKey: 'ctrl+g'
        };
        // Create an instance on TransliterationControl with the required
        // options.
        transliterationControl =
          new google.elements.transliteration.TransliterationControl(options);

        // Enable transliteration in the textfields with the given ids.
        var ids = [ TXTCONTROL ];
        transliterationControl.makeTransliteratable(ids);

        // Add the STATE_CHANGED event handler to correcly maintain the state
        // of the checkbox.
        transliterationControl.addEventListener(
            google.elements.transliteration.TransliterationControl.EventType.STATE_CHANGED,
            transliterateStateChangeHandler);

        // Add the SERVER_UNREACHABLE event handler to display an error message
        // if unable to reach the server.
        transliterationControl.addEventListener(
            google.elements.transliteration.TransliterationControl.EventType.SERVER_UNREACHABLE,
            serverUnreachableHandler);

        // Add the SERVER_REACHABLE event handler to remove the error message
        // once the server becomes reachable.
        transliterationControl.addEventListener(
            google.elements.transliteration.TransliterationControl.EventType.SERVER_REACHABLE,
            serverReachableHandler);

        // Populate the language dropdown
        var destinationLanguage =
          transliterationControl.getLanguagePair().destinationLanguage;
          
          
          // parse the XML
          XMLParse(XMLFILE);
    
      }

      // Handler for STATE_CHANGED event which makes sure checkbox status
      // reflects the transliteration enabled or disabled status.
      function transliterateStateChangeHandler(e) 
      {
        //document.getElementById('checkboxId').checked = e.transliterationEnabled;
      }

     
     
      // Handler for dropdown option change event.  Calls setLanguagePair to
      // set the new language.
     function languageChangeHandler() 
     {
        
        var dropdown = document.getElementById(DROPDOWN);
        transliterationControl.setLanguagePair(
            google.elements.transliteration.LanguageCode.ENGLISH,
            dropdown.options[dropdown.selectedIndex].value);
            document.getElementById(HIDDENCONTROL).value= LangKB[dropdown.selectedIndex];
            if(LABELCONTROL !="" && LABELCONTROL !=null)
                document.getElementById(LABELCONTROL).innerHTML="Type in "+dropdown.options[dropdown.selectedIndex].text; 
      }


      // SERVER_UNREACHABLE event handler which displays the error message.
      function serverUnreachableHandler(e) 
      {
        alert("!!!!!!!!!Error!!!!!\r\nTransliteration Server unreachable\r\nplease try again.\r\nSorry For the Inconvenience caused ");
      }

      // SERVER_UNREACHABLE event handler which clears the error message.
      function serverReachableHandler(e) 
      {
        //document.getElementById("errorDiv").innerHTML = "";
      }
      
      
      //sets the callback function
      
      google.setOnLoadCallback(onLoad);
      
      
      
   var LangKB=new Array();//array used stores the keyboard Language
   var AllowMultiple="N";//variabl used check for the Multiple Language is available or not.
    
    // function check the browser and load the xml..
        function loadXMLDoc(dname)
        {
           
            try //Internet Explorer
              {
              xmlD=new ActiveXObject("Microsoft.XMLDOM");
              }
            catch(e)
              {
                  try //Firefox, Mozilla, Opera, etc.
                    {
                    xmlD=document.implementation.createDocument("","",null);
                    }
                  catch(e) {alert(e.message)}
             }
            try
            {
              xmlD.async=false;// sets asynchronous load tio false;
              xmlD.load(dname);
              return(xmlD);
            }
            catch(e) {alert(e.message)}
            return(null);
       }//Function 
       
       
       // function for xml parsing
       function XMLParse(xmlFile)
       {
      
//            xmlDoc=loadXMLDoc("../XMLLanguageTranslation/LanguageTranslation.config.xml");
            xmlDoc=loadXMLDoc(xmlFile);
            var languageSelect="";
            
           
            
            //Check For  Multiple Languages
            AllowMultiple=xmlDoc.getElementsByTagName("Langauges")[0].getAttribute("AllowMultiple");
            //xmlDoc.getElementsByTagName("note")[0].getAttribute("id");
            
             if(AllowMultiple.toUpperCase()=="Y")
             {
                 if(DROPDOWN =="" || DROPDOWN ==null)
                 {
                    alert("!!!!!!!Technical Error!!!!!!!!!!!!!!!! \r\n\r\n Provide Drop down list for Multiple language selection ");
                 }
                 else
                 {
                    languageSelect = document.getElementById(DROPDOWN);
                 }
             }
            
            x=xmlDoc.getElementsByTagName("Language");
            
            for (i=0;i<x.length;i++)
            { 
              var tr= x[i].getElementsByTagName("Transliterate");
              var kbl=x[i].getElementsByTagName("KeyBoard");
              LangKB[i]= kbl[0].getAttribute("Code");
              //x[i].getElementsByTagName("KeyBoard")[0].getAttribute("Code")
              
              //Drop Down Fill
              var opt;
              if(languageSelect !="")
              {
                opt = document.createElement('option');
                opt.text =  tr[0].getAttribute("Name");
                opt.value = tr[0].getAttribute("Code");
              }
              if (tr[0].getAttribute("Default").toUpperCase() == "Y") 
              {
               if(languageSelect !="" && languageSelect!=null)
                    opt.selected = true;
                
                document.getElementById(HIDDENCONTROL).value=LangKB[i];
                if(LABELCONTROL !="" && LABELCONTROL !=null)
                document.getElementById(LABELCONTROL).innerHTML="Type in "+tr[0].getAttribute("Name"); 
               
                 transliterationControl.setLanguagePair(
                            google.elements.transliteration.LanguageCode.ENGLISH,
                            tr[0].getAttribute("Code"));
              }
              try 
              {
                 if(languageSelect !="" && languageSelect !=null)
                    languageSelect.add(opt, null);
              } catch (ex) 
              {
                 if(languageSelect !="" && languageSelect !=null)
                    languageSelect.add(opt);
              }
              
            }
            
            //check for Multuple Language is available or not and hiding the row of drop down
//            if(DROPDOWN !="" && DROPDOWN !=null)
//            {
//                if(AllowMultiple.toUpperCase()!="Y")
//                {
//                    document.getElementById(ROW).style.display='none';
//                }
//                else
//                {
//                    document.getElementById(ROW).style.display='';
//                }
//            } 
        }
        