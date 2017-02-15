﻿

namespace Cinema.Movie {
    export class ServiceRatingForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.ServiceRating';
    }

    export interface ServiceRatingForm {
        Rating: Serenity.DecimalEditor;
        Id: Serenity.IntegerEditor;
        MovieId: Serenity.IntegerEditor;
        ServiceId: Serenity.IntegerEditor;
    }

    [['Rating', () => Serenity.DecimalEditor], ['Id', () => Serenity.IntegerEditor], ['MovieId', () => Serenity.IntegerEditor], ['ServiceId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ServiceRatingForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}