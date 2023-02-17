import { TestBed, ComponentFixture, fakeAsync, tick } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

import { FetchDataComponent } from './fetch-data.component';

describe('FetchDataComponent', () => {
  let component: FetchDataComponent;
  let fixture: ComponentFixture<FetchDataComponent>;
  let httpMock: HttpTestingController;
  const activatedRouteMock = {
    snapshot: {
      paramMap: {
        get: (param: string) => {
          switch (param) {
            case 'origin':
              return 'MEX';
            case 'destination':
              return 'NYC';
            case 'maxFlights':
              return '2';
            default:
              return null;
          }
        },
      },
    },
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FetchDataComponent],
      imports: [HttpClientTestingModule],
      providers: [{ provide: ActivatedRoute, useValue: activatedRouteMock }],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchDataComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    fixture.detectChanges();
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should complete journey correctly', () => {
    const journey : Journey = {
      flights: [],
      origin: 'MEX',
      destination: 'NYC',
      price: 100,
      priceYen: 300000,
      priceCop: 450000,
      priceMex: 100,
      priceUSD: 100,
    };
    component.completeJourney(journey);
    expect(journey.priceUSD).toEqual(journey.price * 1);
    expect(journey.priceYen).toEqual(journey.price * 3000);
    expect(journey.priceCop).toEqual(journey.price * 4500);
    expect(journey.priceMex).toEqual(journey.price * 60);
  });

  it('should multiply journey price correctly', () => {
    const journey : Journey = {
      flights: [],
      origin: 'MEX',
      destination: 'NYC',
      price: 100,
      priceYen: 300000,
      priceCop: 450000,
      priceMex: 100,
      priceUSD: 100,
    };
    component.currency = 'MEX';
    component.multiplyValue(journey as Journey);
    expect(journey.price).toEqual(journey.priceMex);

    component.currency = 'COP';
    component.multiplyValue(journey);
    expect(journey.price).toEqual(journey.priceCop);

    component.currency = 'YEN';
    component.multiplyValue(journey);
    expect(journey.price).toEqual(journey.priceYen);

    component.currency = 'USD';
    component.multiplyValue(journey);
    expect(journey.price).toEqual(journey.priceUSD);
  });
  
} )
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
  
