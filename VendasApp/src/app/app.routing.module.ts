import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', loadChildren: 'app/components/com um/comum.module#ComumModule', pathMatch: 'full'  },
    { path: 'auth', loadChildren: 'app/components/auth/auth.module#AuthModule', pathMatch: 'full'  },
    { path: 'admin', loadChildren: 'app/components/admin/admin.module#AdminModule', pathMatch: 'full'  },
    { path: '', redirectTo: '/', pathMatch: 'full' },
    { path: '**', redirectTo: '/' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
})

export class AppRoutingModule { }
