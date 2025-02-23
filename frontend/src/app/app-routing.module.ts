import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPage } from './pages/login/login.page';
import { HomePage } from './pages/home/home.page';
import { authGuard } from './core/guards/auth.guard';
import { PricingDetails } from './pages/pricing-details/pricing-details.page';

const routes: Routes = [
    {
        path: "login",
        component: LoginPage,
    },
    {
        path: "",
        component: HomePage,
        canActivate: [authGuard]
    },
    {
        path: "p/:id",
        component: PricingDetails,
        canActivate: [authGuard]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
