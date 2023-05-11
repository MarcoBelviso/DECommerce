import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DecommerceApiService } from './decommerce-api.service';
import { Configuration } from '../models/Configuration';


@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  constructor(private http : HttpClient, private DECservice : DecommerceApiService) { }

  initialize(){
    //TODO RETURN DEVE DIVENTARE UNA VARIABILE, A CUI POI ACCEDIAMO RICHIAMANDO IL SERVICE IN TUTTI I COMPONENTI
     this.http.get(this.DECservice.DECommerceApiUrl + '/Configurations').subscribe((x : any)=>{
      this.configuration = x;
     }
     );
  }

  configuration : Configuration

  isVisible(componentName:string, fieldName:string)
  {
   let isVisible =  this.configuration.pages.find(x=> x.name === componentName)?.fields.find(x=> x.name == fieldName)?.isVisible;

   return isVisible;
  }

  getText(componentName:string, fieldName:string)
  {
   let text=  this.configuration.pages.find(x=> x.name === componentName)?.fields.find(x=> x.name == fieldName)?.text;

   return text;
  }

}
