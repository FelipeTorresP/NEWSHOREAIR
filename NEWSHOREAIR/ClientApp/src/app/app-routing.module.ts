import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";

const routes: Routes = [
    { path: "fetch-data/:origin,destination,maxFlights", component: FetchDataComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }