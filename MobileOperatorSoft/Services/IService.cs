﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOperatorSoft.Services
{
    interface IService<T>
    {
        T Read(int id);

        List<T> ReadAll();

        int Create(T entity);

        Boolean Update(int id, T entity);

        Boolean Delete(int id);
    }
}
