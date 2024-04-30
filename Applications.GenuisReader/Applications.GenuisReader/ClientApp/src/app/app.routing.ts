import { Route } from "@angular/router"
import { HomeComponent } from "./components/home/home.component";
import { SeriesSummaryComponent } from "./components/series/series-summary/series-summary.component";
import { AddSeriesComponent } from "./components/series/add-series/add-series.component";

export const routes = [
    { path: 'home', component: HomeComponent },
    { path: 'series/add', component: AddSeriesComponent },
    { path: 'series', component: SeriesSummaryComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
] as Route[];