import { Component } from '@angular/core';
import { Currency, CurrencyClient } from '../web-api-client';

@Component({
  selector: 'app-currency-data',
  templateUrl: './currency-data.component.html'
})
export class CurrencyDataComponent {
  public currencies: Currency[];

  constructor(private client: CurrencyClient) {
    client.get().subscribe(result => {
debugger;
      this.currencies = result;
    }, error => console.error(error));
  }
}
