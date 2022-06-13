﻿using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void Add(ProductViewModel product)
        {
            var result = _mapper.Map<Product>(product);
            _productRepository.Add(result);            
        }

        public async Task<ProductViewModel> GetById(int? id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(product);

        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public void Remove(int? id)
        {
            var product = _productRepository.GetById(id).Result;
            _productRepository.Remove(product);
        }

        public void Update(ProductViewModel product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            _productRepository.Update(mapProduct);
        }
    }
}
