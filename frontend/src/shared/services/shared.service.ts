import { Injectable } from '@angular/core';

@Injectable()
export class SharedService {
  constructor() { }
}

export class DefaultResponse{
  result: any
  errorMessage: string
  executionTime: any
  isSuccess: boolean
}
