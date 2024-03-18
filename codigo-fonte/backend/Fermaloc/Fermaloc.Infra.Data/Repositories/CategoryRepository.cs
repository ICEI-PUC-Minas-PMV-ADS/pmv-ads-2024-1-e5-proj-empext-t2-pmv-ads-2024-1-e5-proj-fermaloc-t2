﻿using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
namespace Fermaloc.Infra.Data;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }
    public async Task<Category> GetCategoryByIdAsync(Guid id)
    {
        Category category = await _context.Categories.FindAsync(id);
        return category;
    }
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        IEnumerable<Category> categories = await _context.Categories.ToListAsync();
        return categories;
    }
    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }
    public async Task<Category> DeleteCategoryAsync(Guid id)
    {
        Category category = await _context.Categories.FindAsync(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}