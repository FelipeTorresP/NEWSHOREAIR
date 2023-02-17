import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse  } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import Swal from 'sweetalert2';
import { catchError } from 'rxjs';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  journeyRequest: JourneyRequest;
  public journeys : Journey[] = [];
  public currency : string = "";

 
  constructor(private route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   
    this.journeyRequest = { origin: this.route.snapshot.paramMap.get('origin')??"", destination: this.route.snapshot.paramMap.get('destination')??"", maxFlights:parseInt( this.route.snapshot.paramMap.get('maxFlights') ??'0')};
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = JSON.stringify( this.journeyRequest);

    http.post(baseUrl+ 'journey', body, {headers} ).subscribe(response => {
      this.journeys = response as Journey[]; 
      this.journeys.forEach(journey => {this.completeJourney(journey);});
    },error =>{ Swal.fire('Error', error.message, 'error')},
    () => {  Swal.fire('Success', 'Journeys found', 'success')  }
    );
    
  }
  completeJourney(journey: Journey) {
    journey.priceUSD = journey.price * 1;
    journey.priceYen = journey.price * 3000;
    journey.priceCop = journey.price * 4500;
    journey.priceMex = journey.price * 60;
    console.log(journey);
  }
  multiplyValue(journey: Journey) {    

    if  (this.currency == "MEX") {
      journey.price= journey.priceMex ;
    }  
    if  (this.currency == "COP") {
      journey.price= journey.priceCop ;
    } 
    if  (this.currency == "YEN") {
      journey.price= journey.priceYen ;
    } 
    if  (this.currency == "USD") {
      journey.price= journey.priceUSD ;
    }   
    
  }

}


interface JourneyRequest {
  origin: string;
  destination: string;
  maxFlights: number;
}
interface Journey {
  flights: Flight[];
  origin: string;
  destination: string;
  price: number;
  priceYen: number;
  priceCop: number;
  priceMex: number;
  priceUSD: number;
}
interface Flight {
  transport: Transport;
  origin: string;
  destination: string;
  price: number;
}
interface Transport {
  flightCarrier: string;
  flightNumber: number;
}
