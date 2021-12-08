import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoadingService } from '../services/loading.service';
import { finalize } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  totalRequests: number = 0;
  completedRequests: number = 0;

  constructor(private loadingService: LoadingService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    this.loadingService.startLoading();
    this.totalRequests ++;
    return next.handle(request).pipe(
      finalize(() => {
          this.completedRequests ++;

          if (this.completedRequests === this.totalRequests) {
            this.loadingService.stopLoading()
            this.completedRequests = 0;
            this.totalRequests = 0;
          }

        }
      )
    )
  }
}
