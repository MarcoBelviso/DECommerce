import { Component } from '@angular/core';
import { ConfigurationService } from './services/configuration.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DECommerceFE';

  configurations : String

  constructor(private ConfigurationsService : ConfigurationService ){}

  ngOnInit(): void {
    this.ConfigurationsService.initialize();
    console.log(this.ConfigurationsService.initialize())
  }

}
