import { ValidationErrors } from "@angular/forms";

export class ErroResponse{

  public static findError(parametro: string, errors: ValidationErrors | null): string {
    if(errors?.['required']) {
      return `${parametro.toUpperCase()}: preencha o campo`;
    }else if(errors?.['minlength']) {
      return `${parametro.toUpperCase()}: pode conter no mínimo ${errors['minlength'].requiredLength} caracteres`;
    }else if(errors?.['maxlength']) {
      return `${parametro.toUpperCase()}: pode conter no máximo ${errors['maxlength'].requiredLength} caracteres`;
    }else if(errors?.['min']) {
      return `${parametro.toUpperCase()}: o valor mínimo é ${errors['min'].min}.`;
    }else if(errors?.['max']) {
      return `${parametro.toUpperCase()}: o valor máximo é ${errors['max'].max}.`;
    }
    return "";
  }

}
