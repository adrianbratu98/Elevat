import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoadingService } from '../services/loading.service';
import { finalize } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  loadingCount: number = 0;


  constructor(private loadingService: LoadingService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {

    this.loadingService.startLoading();

    this.loadingCount++;

    return next.handle(request).pipe(
      finalize(() => {
          this.loadingCount--;
          if(this.loadingCount == 0)
            this.loadingService.stopLoading(); 
        }
      )
    )
  }
}
