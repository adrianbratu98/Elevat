import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  loadingState: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() { }

  startLoading() {
    this.loadingState.emit(true)
  }

  stopLoading() {
    this.loadingState.emit(false)
  }
}
